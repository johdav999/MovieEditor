using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieEditor.Client.Models;

public sealed class Project
{
    public string Name { get; set; } = "Untitled Project";
    public List<MediaAsset> Assets { get; } = new();
    public Timeline Timeline { get; } = new();

    public IReadOnlyList<string> Validate()
    {
        var errors = new List<string>();

        var totalBytes = Assets.Sum(asset => asset.SizeBytes);
        if (totalBytes > FreeTierLimits.MaxTotalImportBytes)
        {
            errors.Add($"Total import size exceeds {FreeTierLimits.MaxTotalImportSizeLabel}.");
        }

        foreach (var asset in Assets)
        {
            if (asset.DurationMs.HasValue && asset.DurationMs.Value > FreeTierLimits.MaxClipDurationSeconds * 1000L)
            {
                errors.Add($"Asset '{asset.FileName}' exceeds {FreeTierLimits.MaxClipDurationSeconds}s per-clip limit.");
            }

            if (!string.IsNullOrWhiteSpace(asset.VideoCodec)
                && !string.Equals(asset.VideoCodec, FreeTierLimits.SupportedVideoCodec, StringComparison.OrdinalIgnoreCase))
            {
                errors.Add($"Asset '{asset.FileName}' must be {FreeTierLimits.SupportedInputLabel}.");
            }

            if (!string.IsNullOrWhiteSpace(asset.AudioCodec)
                && !string.Equals(asset.AudioCodec, FreeTierLimits.SupportedAudioCodec, StringComparison.OrdinalIgnoreCase))
            {
                errors.Add($"Asset '{asset.FileName}' must be {FreeTierLimits.SupportedInputLabel}.");
            }
        }

        var clipCount = Timeline.AllClips.Count();
        if (clipCount > FreeTierLimits.MaxClips)
        {
            errors.Add($"Timeline exceeds {FreeTierLimits.MaxClips} clips.");
        }

        foreach (var clip in Timeline.AllClips)
        {
            if (!Assets.Any(asset => asset.Id == clip.AssetId))
            {
                errors.Add("Timeline references an asset that does not exist in the project.");
                break;
            }

            if (clip.DurationSeconds > FreeTierLimits.MaxClipDurationSeconds)
            {
                errors.Add($"A clip exceeds {FreeTierLimits.MaxClipDurationSeconds}s per-clip limit.");
                break;
            }
        }

        return errors;
    }
}
