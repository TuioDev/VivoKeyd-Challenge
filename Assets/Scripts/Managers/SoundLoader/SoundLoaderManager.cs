using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SoundLoaderManager : Singleton<SoundLoaderManager>
{
    public SoundLoaderResult LastGetAudioClipAsync { get; private set; }
    public bool IsGetAudioClipAsyncRunning { get; private set; }

    public SoundLoaderResult GetAudioClip(string audioPath, AudioType audioType)
    {
        UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(audioPath, audioType);
        request.SendWebRequest();
        while (!request.isDone) { }

        return GetSoundLoaderResultWithWebRequest(request);
    }

    public IEnumerator GetAudioClipAsync(string audioPath, AudioType audioType)
    {
        IsGetAudioClipAsyncRunning = true;

        using UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(audioPath, audioType);
        yield return request.SendWebRequest();

        LastGetAudioClipAsync = GetSoundLoaderResultWithWebRequest(request);
        IsGetAudioClipAsyncRunning = false;
    }

    private SoundLoaderResult GetSoundLoaderResultWithWebRequest(UnityWebRequest request)
    {
        string error = string.Empty;
        AudioClip audioClip = null;

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            error = request.error;
        }
        else
        {
            audioClip = DownloadHandlerAudioClip.GetContent(request);
        }

        return new SoundLoaderResult(error, audioClip);
    }
}