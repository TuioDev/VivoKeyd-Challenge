using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SpawnManager : ConductionDependetSingleton<SpawnManager>
{
    [SerializeField] private List<Transform> HittablesPrefabs;

    public List<HittableObject> SpawnedAlready { get; private set; }
    public List<HittableObject> HittablesToSpawn { get; private set; }

    protected override void Awake()
    {
        SpawnedAlready = new List<HittableObject>();
        base.Awake();
    }
    public override void OnMoveToNewBeat(ConductorSongInformation conductorSongInformation)
    {
        SpawnByBeat((int)conductorSongInformation.SongPositionInBeats);
    }

    public void SpawnByBeat(int beat)
    {
        List<HittableObject> hittables = HittablesToSpawn.FindAll(hittable => hittable.ShowUpBeat == beat && !SpawnedAlready.Contains(hittable));
        if (hittables == null || hittables.Count == 0) return;

        foreach(HittableObject hittable in hittables)
        {
            //Debug.Log($@"Spawned #{hittable.HittableName}");
            SpawnedAlready.Add(hittable);
            HittableManager.Instance.AddHittable(hittable);

            Transform newHittable = HittablesPrefabs.Find(t => t.name == hittable.HittableName);
            for(int laneIndex = 0; laneIndex < hittable.LanesOccupation.Count; laneIndex++)
            {
                if (!hittable.LanesOccupation[laneIndex]) continue;

                Tuple<int, Vector3> indexAndPosition = GetSpawnPositionInLane(laneIndex);
                hittable.CurrentIndexInLane = indexAndPosition.Item1;

                Transform hittablesParentInLane = LevelManager.Instance.GetHittablesParentInLane(laneIndex).transform;
                hittable.transform = Instantiate(newHittable, indexAndPosition.Item2, Quaternion.identity, hittablesParentInLane);
                hittable.transform.name = hittable.GUID;
            }
        }
    }

    private Tuple<int, Vector3> GetSpawnPositionInLane(int laneIndex)
    {
        int maxLaneSlotIndex = LevelManager.Instance.MaxSlotPositionInLane(laneIndex);
        return new(maxLaneSlotIndex, LevelManager.Instance.GetSlotPositionInLane(laneIndex, maxLaneSlotIndex));
    }

    public void UpdateSpawnManagerHittablesList()
    {
        HittablesToSpawn = LevelManager.Instance.CurrentMusicConfiguration.Hittables;
    }
}
