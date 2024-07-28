using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VideoClipper.Infrastructure.Repositories;

namespace VideoClipper.Infrastructure;

internal class DesignDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
	public ApplicationDbContext CreateDbContext(string[] args)
	{
		var dbPath = Path.Combine(Environment.CurrentDirectory, "Design.db");
		if (!File.Exists(dbPath))
			throw new Exception($"Design db at {dbPath} does not appear to exist.");
		
		var options = new DbContextOptionsBuilder<ApplicationDbContext>();
		options.UseSqlite($"Data Source=\"{dbPath}\";");
		return new ApplicationDbContext(options.Options);
	}
}