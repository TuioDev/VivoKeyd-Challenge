using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LevelManager : Singleton<LevelManager>
{
    //[SerializeField] private MusicConfiguration currentMusicConfiguration;
    public MusicConfiguration CurrentMusicConfiguration { get; private set; }
    public AudioClip CurrentAudioClip { get; private set; }
    public bool IsLoadingAudioClip { get; private set; }
    public string ErrorLoadingAudioClip { get; private set; }

    protected override void Awake()
    {
        CurrentMusicConfiguration = ScriptableObject.CreateInstance<MusicConfiguration>();
        base.Awake();
    }

    public void LoadBuiltInLevel(int levelIndex)
    {
        string filesPath = $@"Assets/Levels/Level{levelIndex}";
        
        CurrentMusicConfiguration = LevelLoader.LoadFromLocalJSON(CurrentMusicConfiguration, filesPath);
        
        StartCoroutine(SetCurrentAudioClip($@"file://{filesPath}/{CurrentMusicConfiguration.file}", AudioType.MPEG));
    }

    private IEnumerator SetCurrentAudioClip(string audioPath, AudioType audioType)
    {
        ErrorLoadingAudioClip = string.Empty;
        IsLoadingAudioClip = true;
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(audioPath, audioType))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                ErrorLoadingAudioClip = request.error;
                Debug.Log(ErrorLoadingAudioClip);
            }
            else
            {
                CurrentAudioClip = DownloadHandlerAudioClip.GetContent(request);
            }
        }
        IsLoadingAudioClip = false;
    }
}
