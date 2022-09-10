using System;
using UnityEngine;

public class ConductorSongInformation : ICloneable
{
    public float Pitch { get; private set; }
    public float MinutesPerBeat { get; private set; }
    public float SecondsPerBeat => 60f / MinutesPerBeat;
    public float FirstBeatOffset { get; private set; }
    public float SongPositionInSeconds { get; private set; }
    public float SongPositionInBeats => SongPositionInSeconds / SecondsPerBeat;

    //How many seconds have passed since the song started
    public float DspSongTime { get; private set; }

    // This value shows how fast the notes will travel between begin and end
    public float BeatsSpawnOffset = 24f;
    //public float AnimationbeatsPerLoop;
    //public int CompletedLoops = 0;

    public ConductorSongInformation(float minutesPerBeat, float pitch, float firstBeatOffset, float dspSongTime)
    {
        MinutesPerBeat = minutesPerBeat;
        Pitch = pitch;
        FirstBeatOffset = firstBeatOffset;
        DspSongTime = dspSongTime;

        UpdateSongPositionInSeconds();
    }

    public ConductorSongInformation(float minutesPerBeat, float pitch, float firstBeatOffset, float dspSongTime, float songPositionInSeconds)
    {
        MinutesPerBeat = minutesPerBeat;
        Pitch = pitch;
        FirstBeatOffset = firstBeatOffset;
        DspSongTime = dspSongTime;
        SongPositionInSeconds = songPositionInSeconds;
    }

    public void UpdateSongPositionInSeconds()
    {
        var dspNow = (float)AudioSettings.dspTime;
        //Debug.Log($@"Original DSP #{DspSongTime}, Actual DSP #{dspNow}, Pitch #{Pitch}, OffSet #{FirstBeatOffset}");
        SongPositionInSeconds = ((dspNow - DspSongTime) * Pitch) - FirstBeatOffset;
    }

    public object Clone()
    {
        return new ConductorSongInformation(
            MinutesPerBeat,
            Pitch,
            FirstBeatOffset,
            DspSongTime,
            SongPositionInSeconds
        );
    }
}