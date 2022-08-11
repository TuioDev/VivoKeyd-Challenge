public partial class LevelLoaderConfiguration
{
    public static LevelLoaderConfiguration LocalJSONFile(MusicConfiguration musicConfiguration, string filesPath)
    {
        return new LevelLoaderConfiguration() {
            MusicConfiguration = musicConfiguration,
            FileType = LevelLoaderFileType.Json,
            FilePath = $@"{filesPath}/Level.json",
            IsLocalFile = true,
            IsMobileDevice = false
        };
    }
}