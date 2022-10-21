using Baracuda.Monitoring;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicConfiguration : MonitoredScriptableObject
{
    [Monitor]
    public string MusicName;
    [Monitor]
    public string Artist;
    [Monitor]
    public string File;
    [Monitor]
    public AudioType AudioType;
    [Monitor]
    public int AmountOfLanes;
    [Monitor]
    public int AmountOfLaneSlots;
    public List<TimingConfiguration> Timings = new();
    public List<HittableObject> Hittables = new();
}