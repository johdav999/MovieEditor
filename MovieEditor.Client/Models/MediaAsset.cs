namespace MovieEditor.Client.Models;

public sealed class MediaAsset
{
    public Guid Id { get; } = Guid.NewGuid();
    public string FileName { get; set; } = string.Empty;
    public long SizeBytes { get; set; }
    public string MimeType { get; set; } = string.Empty;
    public long? DurationMs { get; set; }
    public string? VideoCodec { get; set; }
    public string? AudioCodec { get; set; }
}
