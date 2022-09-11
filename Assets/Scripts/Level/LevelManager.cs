using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : Singleton<LevelManager>
{
    public MusicConfiguration CurrentMusicConfiguration { get; private set; }
    public AudioClip CurrentAudioClip { get; private set; }
    [SerializeField] private GameObject BaseLane;
    [SerializeField] private float LaneOffSetX;
    [SerializeField] private float LaneOffSetY;
    public Dictionary<int, Vector3> PlayerPositionPerLane { get; private set; }
    public int MaxLaneIndex => PlayerPositionPerLane.Keys.Max();
    public int MinLaneIndex => PlayerPositionPerLane.Keys.Min();

    protected override void Awake()
    {
        CurrentMusicConfiguration = ScriptableObject.CreateInstance<MusicConfiguration>();
        PlayerPositionPerLane = new Dictionary<int, Vector3>();
        base.Awake();
    }

    public void LoadBuiltInLevel(int levelIndex)
    {
        string filesPath = $@"{Application.dataPath}/Levels/Level{levelIndex}";
        
        CurrentMusicConfiguration = LevelLoader.LoadFromLocalJSON(CurrentMusicConfiguration, filesPath);
        var result = SoundLoaderManager.Instance.GetAudioClip($@"file://{filesPath}/{CurrentMusicConfiguration.File}", AudioType.WAV);

        if(result.ErrorLoadingAudioClip != "")
        {
            Debug.LogError(result.ErrorLoadingAudioClip);
        } 
        else
        {
            CurrentAudioClip = result.AudioClip;
        }

        CreateLanesInLevel(CurrentMusicConfiguration.AmountOfLanes);
        SpawnManager.Instance.UpdateSpawnManagerList();
    }

    public void CreateLanesInLevel(int ammountOfLanes)
    {
        Vector3 lastPosition = BaseLane.transform.position;
        PlayerPositionPerLane.Add(0, GetPlayerPositionInLane(BaseLane));

        for (int index = 0; index < ammountOfLanes - 1; index++)
        {
            Vector3 newPosition = new(lastPosition.x + LaneOffSetX, lastPosition.y + LaneOffSetY, 0);
            var newLane = Instantiate(BaseLane, newPosition, Quaternion.identity, BaseLane.transform.parent);
            PlayerPositionPerLane.Add(index + 1, GetPlayerPositionInLane(newLane));

            lastPosition = newPosition;
        }
    }

    private Vector3 GetPlayerPositionInLane(GameObject Lane)
    {
        return Lane.transform.Find("PlayerLanePosition").transform.position;
    }
}
