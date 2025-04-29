using VideoClipper.Domain.Primitives;

namespace VideoClipper.Domain.Entities;

public class Project
{
	public ProjectId Id { get; set; }
	
	public required ProjectKind ProjectKind { get; init; }
	
	public required string Name { get; init; }

	private List<VideoFile> _videoFiles = new();
	public IReadOnlyList<VideoFile> VideoFiles => _videoFiles;
}

public class VideoFile
{
	public VideoFileId Id { get; set; }

	public ProjectId ProjectId { get; set; }

	public required string FilePath { get; set; }
	
	private List<Section> _sections = new();
	public IReadOnlyList<Section> Sections => _sections;
}

public class Section
{
	public SectionId Id { get; set; }
	public VideoFileId VideoFileId { get; set; }
	public TimeSpan? Start { get; set; }
	public TimeSpan? End { get; set; }

	public string? Name { get; set; }

	private List<SectionTag> _tags = new();
	public IReadOnlyList<SectionTag> Tags => _tags;
}

public class SectionTag
{
	public SectionTagId Id { get; set; }

	public required string TagName { get; set; }
}