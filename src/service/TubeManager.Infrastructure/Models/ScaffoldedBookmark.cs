using System;
using System.Collections.Generic;

namespace TubeManager.Infrastructure.Models;

public partial class ScaffoldedBookmark
{
    public string YouTubeVideoId { get; set; } = null!;

    public byte[]? YouTubeVideo { get; set; }

    public int? OrderIndex { get; set; }
}
