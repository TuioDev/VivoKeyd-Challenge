using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SpawnManager : Singleton<SpawnManager>
{
    public List<Transform> spawnPositionReference;
    public List<Transform> endPositionReference;
    public List<Transform> hittablesPrefabs;

    public List<HittableObject> SpawnedAlready { get; private set; }
    public List<HittableObject> Hittables { get; private set; }
    public HittableObject hittable;

    // If we use float, this value is the minimum value between hittables
    public float beatThresholdValue;

    protected override void Awake()
    {
        SpawnedAlready = new List<HittableObject>();
        Hittables = new List<HittableObject>();
        base.Awake();
    }

    public void SpawnByBeat(int beat)
    {
        do
        {
            hittable = Hittables.Find(hittable => hittable.showUpBeat == beat && !SpawnedAlready.Contains(hittable));
            SpawnedAlready.Add(hittable);
            if (hittable != null)
            {
                Transform newHittable = (hittablesPrefabs.Find(t => t.name == hittable.hittableName));
                Vector3 prefabPosition = GetHittableSpawnPosition(hittable.lanesOccupation.IndexOf(true));
                Transform newPrefab = Instantiate(newHittable, prefabPosition, Quaternion.identity);

                newPrefab.GetComponent<HittableBehaviour>().SetHittableInformation(hittable);

                /// Change this for better understanding
                newPrefab.GetComponent<HittableBehaviour>().beginningPosition = prefabPosition;
                newPrefab.GetComponent<HittableBehaviour>().endingPosition = GetHittableEndPosition(hittable.lanesOccupation.IndexOf(true));
            }
        } while (hittable != null);
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
    private bool IsReadyInBeatToSpawn(float hittableBeat, float currentBeat)
    {
        return hittableBeat > currentBeat && hittableBeat < currentBeat + beatThresholdValue;
    }
}
