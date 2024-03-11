using System;
using System.Collections.Generic;

namespace spike_db_scaffold;

public partial class Bookmark
{
    public string YouTubeVideoId { get; set; } = null!;

    public byte[]? YouTubeVideo { get; set; }

    public int? OrderIndex { get; set; }
}
