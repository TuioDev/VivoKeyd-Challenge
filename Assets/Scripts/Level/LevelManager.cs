using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public MusicConfiguration CurrentMusicConfiguration { get; private set; }
    public AudioClip CurrentAudioClip { get; private set; }
    [SerializeField] private GameObject BaseLane;
    [SerializeField] private GameObject LanePrefab;
    [SerializeField] private float LaneOffSetX;
    [SerializeField] private float LaneOffSetY;
    [SerializeField] private float LaneSlotOffSetX;
    [SerializeField] private float LaneSlotOffSetY;
    private Dictionary<int, LaneInformation> Lanes;

    public int MaxSlotPositionInLane(int laneIndex) => Lanes[laneIndex].SlotsPosition.Count - 1;
#pragma warning disable IDE0060 // Remove unused parameter
    public int MinSlotPositionInLane(int laneIndex) => 0;
#pragma warning restore IDE0060 // Remove unused parameter

    protected override void Awake()
    {
        CurrentMusicConfiguration = ScriptableObject.CreateInstance<MusicConfiguration>();
        ClearDictionary();
        base.Awake();
    }

    public void LoadBuiltInLevel(int levelIndex)
    {
        string filesPath = $@"{Application.dataPath}/Levels/Level{levelIndex}";

        CurrentMusicConfiguration = LevelLoader.LoadFromLocalJSON(CurrentMusicConfiguration, filesPath);
        var result = SoundLoaderManager.Instance.GetAudioClip($@"file://{filesPath}/{CurrentMusicConfiguration.File}", CurrentMusicConfiguration.AudioType);

        if (result.ErrorLoadingAudioClip != "")
        {
            Debug.LogError(result.ErrorLoadingAudioClip);
        }
        else
        {
            CurrentAudioClip = result.AudioClip;
        }

        CreateLanesInLevel(CurrentMusicConfiguration.AmountOfLanes, CurrentMusicConfiguration.AmountOfLaneSlots);
        SpawnManager.Instance.UpdateSpawnManagerHittablesList();
    }

    public GameObject GetHittablesParentInLane(int laneIndex)
    {
        return Lanes[FixLaneIndexBoundaries(laneIndex)].HittablesParent;
    }
    public Vector3 GetPlayerPositionInLane(int laneIndex)
    {
        return Lanes[FixLaneIndexBoundaries(laneIndex)].PlayerSlotPosition.position;
    }

    public int FixLaneIndexBoundaries(int laneIndex)
    {
        var min = Lanes.Keys.Min();
        var max = Lanes.Keys.Max(); 

        return laneIndex < min ? min : laneIndex > max ? max : laneIndex;
    }

    public Vector3 GetSlotPositionInLane(int laneIndex, int slotIndex)
    {
        laneIndex = FixLaneIndexBoundaries(laneIndex);
        slotIndex = FixLaneSlotIndexBoundaries(laneIndex, slotIndex);

        return Lanes[laneIndex].SlotsPosition[slotIndex].position;
    }
    public int FixLaneSlotIndexBoundaries(int laneIndex, int slotIndex)
    {
        var min = 0;
        var max = MaxSlotPositionInLane(laneIndex);

        return slotIndex < min ? min : slotIndex > max ? max : slotIndex;
    }

    public void CreateLanesInLevel(int amountOfLanes, int amountOfSlotsPerLane)
    {
        ClearDictionary();

        Vector3 lastPosition = BaseLane.transform.parent.position;
        LaneInformation laneInformation = GetLaneInformation(BaseLane);
        Lanes.Add(0, laneInformation);
        BuildLaneSlots(laneInformation, amountOfSlotsPerLane);

        for (int index = 0; index < amountOfLanes - 1; index++)
        {
            Vector3 newPosition = new(lastPosition.x + LaneOffSetX, lastPosition.y + LaneOffSetY, 0);
            var newLane = Instantiate(LanePrefab, newPosition, Quaternion.identity, BaseLane.transform.parent);
            newLane.name = $@"Lane {index + 1}";

            laneInformation = GetLaneInformation(newLane);
            Lanes.Add(index + 1, laneInformation);
            BuildLaneSlots(laneInformation, amountOfSlotsPerLane);

            lastPosition = newPosition;
        }
    }

    private LaneInformation GetLaneInformation(GameObject lane)
    {
        LaneInformation laneInformation = lane.GetComponent<LaneInformation>();
        return laneInformation;
    }

    private void BuildLaneSlots(LaneInformation laneInformation, int amountOfLaneSlots)
    {
        int preFabIndex = 0;
        Vector3 position = laneInformation.SlotsParent.transform.parent.position;
        for (int slotIndex = 0; slotIndex < amountOfLaneSlots; slotIndex++)
        {
            var slot = Instantiate(laneInformation.PrefabSlots[preFabIndex], position, Quaternion.identity, laneInformation.SlotsParent.transform);
            slot.name = $@"Slot {slotIndex}";
            laneInformation.SlotsPosition.Add(slot);

            position.x += LaneSlotOffSetX;
            position.y += LaneSlotOffSetY;
            preFabIndex = (preFabIndex + 1) % 4;
        }

    }

    private void ClearDictionary()
    {
        if(Lanes != null)
        {
            foreach(LaneInformation laneInformation in Lanes.Values)
            {
                if (!laneInformation.IsBase)
                {
                    Destroy(laneInformation.Lane);
                }
                else
                {
                    for(int index = laneInformation.SlotsPosition.Count - 1; index >= 0; index--)
                    {
                        Destroy(laneInformation.SlotsPosition[index].gameObject);
                        laneInformation.SlotsPosition.RemoveAt(index);
                    }
                }
            }
        }

        Lanes = new();

    }
}