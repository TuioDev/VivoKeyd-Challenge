public partial class LevelLoaderConfiguration
{
    public static LevelLoaderConfiguration LocalJSONFile(MusicConfiguration musicConfiguration, string filePath)
    {
        return new LevelLoaderConfiguration() {
            MusicConfiguration = musicConfiguration,
            FileType = LevelLoaderFileType.Json,
            FilePath = filePath,
            IsLocalFile = true,
            IsMobileDevice = false
        };
    }
}