using System.Collections.Generic;
using System.Linq;
public class SpawnManager : Singleton<SpawnManager>
{
    public List<HittableObject> SpawnedAlready { get; private set; }

    protected override void Awake()
    {
        SpawnedAlready = new List<HittableObject>();
        base.Awake();
    }

    public void SpawnByBeat(int beat)
    {
        var hittables = LevelManager.Instance.CurrentMusicConfiguration.hittables;
        var hittable = hittables.Find(hittable => hittable.showUpBeat == beat && !SpawnedAlready.Contains(hittable));
        if (hittable == null) return;

        //Spawn hittable
        SpawnedAlready.Add(hittable);
    }
}
