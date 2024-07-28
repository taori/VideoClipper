namespace VideoClipper.Domain.Entities;

public class ApplicationConfiguration
{
	public string RootConnectionString { get; set; }
	
	public bool UseProjectDatabase { get; set; }
}