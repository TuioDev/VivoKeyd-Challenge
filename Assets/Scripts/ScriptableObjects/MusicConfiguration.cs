using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicConfiguration : ScriptableObject
{
    public string musicName;
    public string artist;
    public string file;
    public int amountOfLanes;
    public List<TimingConfiguration> timings = new List<TimingConfiguration>();
    public List<HittableObject> hittables = new List<HittableObject>();
}