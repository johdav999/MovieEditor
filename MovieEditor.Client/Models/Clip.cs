namespace MovieEditor.Client.Models;

public sealed class Clip
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid AssetId { get; set; }
    public double DurationSeconds { get; set; }
}
