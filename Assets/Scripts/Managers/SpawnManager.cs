using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SpawnManager : ConductionDependetSingleton<SpawnManager>
{
    public List<Transform> spawnPositionReference;
    public List<Transform> endPositionReference;
    public List<Transform> hittablesPrefabs;

    public List<HittableObject> SpawnedAlready { get; private set; }
    public List<HittableObject> Hittables { get; private set; }

    protected override void Awake()
    {
        SpawnedAlready = new List<HittableObject>();
        Hittables = new List<HittableObject>();
        base.Awake();
    }
    public override void OnMoveToNewBeat(ConductorSongInformation conductorSongInformation)
    {
        SpawnByBeat((int)conductorSongInformation.SongPositionInBeats);
    }

    public void SpawnByBeat(int beat)
    {
        HittableObject hittable = Hittables.Find(hittable => hittable.showUpBeat == beat && !SpawnedAlready.Contains(hittable));
        if (hittable != null)
        {
            SpawnedAlready.Add(hittable);
            Transform newHittable = (hittablesPrefabs.Find(t => t.name == hittable.hittableName));
            Vector3 prefabPosition = GetHittableSpawnPosition(hittable.lanesOccupation.IndexOf(true));
            Transform newPrefab = Instantiate(newHittable, prefabPosition, Quaternion.identity);

            newPrefab.GetComponent<HittableManager>().SetHittableInformation(hittable);

            newPrefab.GetComponent<HittableManager>().beginningPosition = prefabPosition;
            newPrefab.GetComponent<HittableManager>().endingPosition = GetHittableEndPosition(hittable.lanesOccupation.IndexOf(true));
        }
    }

    public void UpdateSpawnManagerList()
    {
        Hittables = LevelManager.Instance.CurrentMusicConfiguration.hittables;
    }

    private Vector3 GetHittableSpawnPosition(int index)
    {
        return spawnPositionReference[index].transform.position;
    }

    private Vector3 GetHittableEndPosition(int index)
    {
        return endPositionReference[index].transform.position;
    }

    // If the beat is a float, we use this to verify if the hittable is ready to spawn
    private bool IsReadyInBeatToSpawn(float hittableBeat, float currentBeat, float beatThresholdValue)
    {
        return hittableBeat > currentBeat && hittableBeat < currentBeat + beatThresholdValue;
    }
}
