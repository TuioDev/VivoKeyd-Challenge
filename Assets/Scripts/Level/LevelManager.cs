using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LevelManager : Singleton<LevelManager>
{
    public MusicConfiguration CurrentMusicConfiguration { get; private set; }
    public AudioClip CurrentAudioClip { get; private set; }

    protected override void Awake()
    {
        CurrentMusicConfiguration = ScriptableObject.CreateInstance<MusicConfiguration>();
        base.Awake();
    }

    public void LoadBuiltInLevel(int levelIndex)
    {
        string filesPath = $@"{Application.dataPath}/Levels/Level{levelIndex}";
        
        CurrentMusicConfiguration = LevelLoader.LoadFromLocalJSON(CurrentMusicConfiguration, filesPath);
        var result = SoundLoaderManager.Instance.GetAudioClip($@"file://{filesPath}/{CurrentMusicConfiguration.file}", AudioType.MPEG);
        if(result.ErrorLoadingAudioClip != "")
        {
            Debug.LogError(result.ErrorLoadingAudioClip);
        } 
        else
        {
            CurrentAudioClip = result.AudioClip;
        }
    }
}
