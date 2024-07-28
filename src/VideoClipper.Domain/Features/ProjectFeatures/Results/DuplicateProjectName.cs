using VideoClipper.Domain.Shared;

namespace VideoClipper.Domain.Features.ProjectFeatures.Results;

public class DuplicateProjectName(string name) : DomainResult<Entities.Project>($"{name} already exists.")
{
}

