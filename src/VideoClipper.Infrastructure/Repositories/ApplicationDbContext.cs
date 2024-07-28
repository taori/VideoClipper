using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using StronglyTypedIds;
using VideoClipper.Domain.Entities;
using VideoClipper.Infrastructure.Toolkit;

namespace VideoClipper.Infrastructure.Repositories;

internal class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<Project> Projects { get; set; }
	public DbSet<VideoFile> VideoFiles { get; set; }
	public DbSet<Section> Sections { get; set; }
	public DbSet<SectionTag> SectionTags { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		StronglyTypedIdModelConverter.AddStronglyTypedIdConversions(modelBuilder);
		base.OnModelCreating(modelBuilder);
	}
}