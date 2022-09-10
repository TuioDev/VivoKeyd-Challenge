using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicConfiguration : ScriptableObject
{
    public string MusicName;
    public string Artist;
    public string File;
    public int AmountOfLanes;
    public List<TimingConfiguration> Timings = new List<TimingConfiguration>();
    public List<HittableObject> Hittables = new List<HittableObject>();
}