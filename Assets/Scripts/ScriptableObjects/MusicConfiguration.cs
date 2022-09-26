using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicConfiguration : ScriptableObject
{
    public string MusicName;
    public string Artist;
    public string File;
    public AudioType AudioType;
    public int AmountOfLanes;
    public int AmountOfLaneSlots;
    public List<TimingConfiguration> Timings = new();
    public List<HittableObject> Hittables = new();
}