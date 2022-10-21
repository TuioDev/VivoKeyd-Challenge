using Baracuda.Monitoring;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicConfiguration : ScriptableObject
{
    [Monitor]
    public string MusicName;
    [Monitor]
    public string Artist;
    [Monitor]
    public string File;
    public AudioType AudioType;
    public int AmountOfLanes;
    public int AmountOfLaneSlots;
    public List<TimingConfiguration> Timings = new();
    public List<HittableObject> Hittables = new();
}