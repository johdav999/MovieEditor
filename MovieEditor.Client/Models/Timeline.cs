using System.Collections.Generic;
using System.Linq;

namespace MovieEditor.Client.Models;

public sealed class Timeline
{
    public List<Clip> VideoTrack { get; } = new();
    public List<Clip> AudioTrack { get; } = new();

    public IEnumerable<Clip> AllClips => VideoTrack.Concat(AudioTrack);
}
