public partial class LevelLoaderConfiguration
{
    public MusicConfiguration MusicConfiguration { get; private set; }
    public LevelLoaderFileType FileType { get; private set; }
    public string FilePath { get; private set; }
    public bool IsLocalFile { get; private set; }
    public bool IsMobileDevice { get; private set; }
}