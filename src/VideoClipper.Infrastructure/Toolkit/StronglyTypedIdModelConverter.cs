using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace VideoClipper.Infrastructure.Toolkit;

internal static class StronglyTypedIdModelConverter
{
	public static void AddStronglyTypedIdConversions(ModelBuilder modelBuilder)
	{
		foreach (var entityType in modelBuilder.Model.GetEntityTypes())
		{
			foreach (var property in entityType.GetProperties())
			{
				if (TryGetStronglyTypedValueType(property.ClrType, out var valueType))
				{
					var converter = StronglyTypedIdConverters.GetOrAdd(
						property.ClrType,
						_ => CreateStronglyTypedIdConverter(property.ClrType, valueType));
					property.SetValueConverter(converter);
					property.ValueGenerated = ValueGenerated.OnAdd;
				}
			}
		}
	}

	private static bool TryGetStronglyTypedValueType(Type propertyClrType, [NotNullWhen(true)]out Type? valueType)
	{
		valueType = default;
		if (propertyClrType.GetCustomAttribute<GeneratedCodeAttribute>() is not { } generatedCodeAttribute)
			return false;
		if (!generatedCodeAttribute.Tool?.Equals("stronglytypedid", StringComparison.OrdinalIgnoreCase) ?? false)
			return false;
		var parameterType = propertyClrType.GetConstructors()
			.Select(d => d.GetParameters() is { Length: 1 } parameters ? parameters[0].ParameterType : default)
			.FirstOrDefault();
		if (parameterType is not null)
		{
			valueType = parameterType;
			return true;
		}
		
		return false;
	}

	private static readonly ConcurrentDictionary<Type, ValueConverter> StronglyTypedIdConverters = new();

	private static ValueConverter CreateStronglyTypedIdConverter(
		Type stronglyTypedIdType,
		Type valueType)
	{
		// id => id.Value
		var toProviderFuncType = typeof(Func<,>)
			.MakeGenericType(stronglyTypedIdType, valueType);
		var stronglyTypedIdParam = Expression.Parameter(stronglyTypedIdType, "id");
		var toProviderExpression = Expression.Lambda(
			toProviderFuncType,
			Expression.Property(stronglyTypedIdParam, "Value"),
			stronglyTypedIdParam);

		// value => new ProductId(value)
		var fromProviderFuncType = typeof(Func<,>)
			.MakeGenericType(valueType, stronglyTypedIdType);
		var valueParam = Expression.Parameter(valueType, "value");
		var ctor = stronglyTypedIdType.GetConstructor(new[] { valueType });
		var fromProviderExpression = Expression.Lambda(
			fromProviderFuncType,
			Expression.New(ctor!, valueParam),
			valueParam);

		var converterType = typeof(ValueConverter<,>)
			.MakeGenericType(stronglyTypedIdType, valueType);

		return (ValueConverter)Activator.CreateInstance(
			converterType,
			toProviderExpression,
			fromProviderExpression,
			null)!;
	}
		
}