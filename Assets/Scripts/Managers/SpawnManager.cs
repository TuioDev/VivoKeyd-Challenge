using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SpawnManager : ConductionDependetSingleton<SpawnManager>
{
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
        List<HittableObject> hittables = Hittables.FindAll(hittable => hittable.ShowUpBeat == beat && !SpawnedAlready.Contains(hittable));
        if (hittables == null || hittables.Count == 0) return;

        foreach(HittableObject hittable in hittables)
        {
            Debug.Log($@"Spawned #{hittable.HittableName}");
            SpawnedAlready.Add(hittable);
            HittableManager.Instance.AddHittable(hittable);

            Transform newHittable = (hittablesPrefabs.Find(t => t.name == hittable.HittableType));
            Vector3 prefabPosition = GetHittableSpawnPosition(hittable.LanesOccupation.IndexOf(true));
            Transform newPrefab = Instantiate(newHittable, prefabPosition, Quaternion.identity);
        }
    }

    public void UpdateSpawnManagerList()
    {
        Hittables = LevelManager.Instance.CurrentMusicConfiguration.Hittables;
    }
}
