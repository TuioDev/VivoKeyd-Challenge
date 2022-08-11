using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : Singleton<Conductor>
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    [SerializeField] private float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    //The offset to the first beat of the song in seconds
    //This is MANUALLY determined, songPosition is negative during these first seconds
    public float firstBeatOffset;

    //the number of beats in each loop OF THE ANIMATION
    //public float beatsPerLoop;

    //the total number of loops completed since the looping clip first started
    public int completedLoops = 0;

    //The current position of the song within the loop in beats.
    //public float loopPositionInBeats;

    //The current relative position of the song within the loop measured between 0 and 1.
    //MOVED TO THE SyncedAnimation, now every animation executes the value for their animation
    //public float loopPositionInAnalog;

    protected override void Awake()
    {
        
    }

    // Start is called before the first frame update
    public void LoadFromLevelManager()
    {
        var music = LevelManager.Instance.CurrentMusicConfiguration;

        //Set the BPM of the song based on the LevelManager current song
        songBpm = music.timings[0].bpm;

        firstBeatOffset = music.timings[0].offSet;

        musicSource = GetComponent<AudioSource>();

        musicSource.volume = music.timings[0].volume;

        musicSource.clip = LevelManager.Instance.CurrentAudioClip;

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;


        //Start the music
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CalculateSongPosition()
    {
        //determine how many seconds since the song started
        songPosition = (float)((AudioSettings.dspTime - dspSongTime) * musicSource.pitch) - firstBeatOffset;

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
    }

}
