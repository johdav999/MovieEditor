namespace MovieEditor.Client.Models;

public static class FreeTierLimits
{
    public const string SupportedContainer = "MP4";
    public const string SupportedVideoCodec = "H.264";
    public const string SupportedAudioCodec = "AAC";

    public const int MaxVideoTracks = 1;
    public const int MaxAudioTracks = 1;
    public const int MaxClips = 20;

    public const int MaxClipDurationSeconds = 120;
    public const int MaxExportDurationSeconds = 120;

    public const int ExportWidth = 1280;
    public const int ExportHeight = 720;
    public const int ExportFps = 30;
    public const int ExportBitrateMbps = 5;

    public const string ExportContainer = "MP4";
    public const string ExportVideoCodec = "H.264";
    public const string ExportAudioCodec = "AAC";

    public const long BytesPerMb = 1024 * 1024;
    public const long MaxTotalImportBytes = 200 * BytesPerMb;

    public static string SupportedInputLabel => $"{SupportedContainer} ({SupportedVideoCodec} video + {SupportedAudioCodec} audio)";
    public static string MaxTotalImportSizeLabel => $"{MaxTotalImportBytes / BytesPerMb} MB";

    public static string ExportLabel =>
        $"{ExportContainer} {ExportVideoCodec}/{ExportAudioCodec}, {ExportHeight}p, {ExportFps}fps, {ExportBitrateMbps} Mbps, max {MaxExportDurationSeconds}s";
}
