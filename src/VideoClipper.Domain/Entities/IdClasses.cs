using System.ComponentModel;
using StronglyTypedIds;

// see: https://github.com/andrewlock/StronglyTypedId
[assembly:StronglyTypedIdDefaults(Template.Int)]

namespace VideoClipper.Domain.Entities;

[StronglyTypedId]
public partial struct ProjectId { }
[StronglyTypedId]
public partial struct VideoFileId { }
[StronglyTypedId]
public partial struct SectionId { }
[StronglyTypedId]
public partial struct SectionTagId { }