using System;
using UnityEngine;

public class Conductor : Singleton<Conductor>
{
    public AudioSource MusicSource;
    private ConductorSongInformation ConductorSongInformation;

    public Action<ConductorSongInformation> MovedToNewBeat;

    public void LoadFromLevelManager()
    {
        var music = LevelManager.Instance.CurrentMusicConfiguration.timings[0];
        MusicSource = GetComponent<AudioSource>();
        MusicSource.volume = music.volume;
        MusicSource.clip = LevelManager.Instance.CurrentAudioClip;

        ConductorSongInformation = new ConductorSongInformation(music.bpm, music.offSet, MusicSource.pitch, (float)AudioSettings.dspTime);

        MusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(MusicSource != null && MusicSource.isPlaying) UpdateSongPosition();
    }

    private void UpdateSongPosition()
    {
        int oldSongPositionInBeats = (int)ConductorSongInformation.SongPositionInBeats;

        ConductorSongInformation.UodateSongPositionInSeconds();
        int newSongPositionInBeats = (int)ConductorSongInformation.SongPositionInBeats;

        if (oldSongPositionInBeats != newSongPositionInBeats) MovedToNewBeat?.Invoke((ConductorSongInformation)ConductorSongInformation.Clone());
    }
}
