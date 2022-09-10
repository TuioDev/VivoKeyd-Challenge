using System.Collections.Generic;
using UnityEngine;

public class HittableManager : ConductionDependetSingleton<HittableManager>
{
    private List<HittableObject> Hittables;

    protected override void Awake()
    {
        Hittables = new List<HittableObject>();
        base.Awake();
    }

    public override void OnMoveToNewBeat(ConductorSongInformation conductorSongInformation)
    {
        foreach(HittableObject hittable in Hittables)
        {
            MoveHittable(hittable, hittable.MovePerBeat);
        }
    }
    public void AddHittable(HittableObject hittable)
    {
        if(!Hittables.Contains(hittable)) Hittables.Add(hittable);
    }

    private void MoveHittable(HittableObject hittable, int amountOfPositions, bool isToMoveAhead = true)
    {

    }

}
