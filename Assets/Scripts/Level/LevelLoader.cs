﻿using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class LevelLoader
{
    public static MusicConfiguration Load(LevelLoaderConfiguration configuration)
    {
        if (configuration.IsLocalFile)
        {
            switch (configuration.FileType)
            {
                case LevelLoaderFileType.Json:
                    string json = File.ReadAllText(configuration.FilePath);
                    configuration.MusicConfiguration = JsonConvert.DeserializeObject<MusicConfiguration>(json);
                    break;
                default:
                    break;
            }
        }

        return configuration.MusicConfiguration;
    }

    public static MusicConfiguration LoadFromLocalJSON(MusicConfiguration musicConfiguration, string filePath)
    {
        return Load(LevelLoaderConfiguration.LocalJSONFile(musicConfiguration, filePath));
    }
}

