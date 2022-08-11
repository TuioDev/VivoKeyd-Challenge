using UnityEngine;

public class SoundLoaderResult
{
    public string ErrorLoadingAudioClip { get; private set; }
    public AudioClip AudioClip { get; private set; }

    public SoundLoaderResult(string errorLoadingAudioClip, AudioClip audioClip)
    {
        ErrorLoadingAudioClip = errorLoadingAudioClip;
        AudioClip = audioClip;
    }
}