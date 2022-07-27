using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicConfiguration : ScriptableObject
{
    public string musicName;
    public string artist;
    public string file;
    public int amountOfLanes;
    public List<TimingConfiguration> timings;
    public List<HittableObject> hittables;
}
