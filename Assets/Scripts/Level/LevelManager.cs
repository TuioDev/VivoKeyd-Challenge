using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private MusicConfiguration currentMusicConfiguration;

    protected override void Awake()
    {
        currentMusicConfiguration = ScriptableObject.CreateInstance<MusicConfiguration>();
    }

    public void LoadBuiltInLevel(int levelIndex)
    {
        string filePath = $@"Assets/Levels/Level{levelIndex}.json";
        currentMusicConfiguration = LevelLoader.LoadFromLocalJSON(currentMusicConfiguration, filePath);
    }
}
