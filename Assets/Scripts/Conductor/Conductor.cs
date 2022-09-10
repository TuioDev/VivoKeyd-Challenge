using System;
using UnityEngine;

public class Conductor : Singleton<Conductor>
{
    public AudioSource MusicSource;
    private ConductorSongInformation ConductorSongInformation;

    public Action<ConductorSongInformation> MovedToNewBeat;

    public void LoadFromLevelManager()
    {
        var music = LevelManager.Instance.CurrentMusicConfiguration.Timings[0];
        MusicSource = GetComponent<AudioSource>();
        MusicSource.volume = music.Volume;
        MusicSource.clip = LevelManager.Instance.CurrentAudioClip;

        ConductorSongInformation = new ConductorSongInformation(music.Bpm, MusicSource.pitch, music.OffSet, (float)AudioSettings.dspTime);

        MusicSource.Play();
    }

    void Update()
    {
        if(MusicSource != null && MusicSource.isPlaying) UpdateSongPosition();
    }

    private void UpdateSongPosition()
    {
        var oldSongPositionInBeats = ConductorSongInformation.SongPositionInBeats;

        ConductorSongInformation.UpdateSongPositionInSeconds();
        var newSongPositionInBeats = ConductorSongInformation.SongPositionInBeats;

        //Debug.Log($@"Old #{oldSongPositionInBeats}, New #{newSongPositionInBeats}");
        if ((int)oldSongPositionInBeats != (int)newSongPositionInBeats)
        {
            //Debug.Log($@"Beat #{newSongPositionInBeats}");
            MovedToNewBeat?.Invoke((ConductorSongInformation)ConductorSongInformation.Clone());
        }
    }
}
