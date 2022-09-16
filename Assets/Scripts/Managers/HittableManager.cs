using System.Collections.Generic;
using UnityEngine;

public class HittableManager : ConductionDependentSingleton<HittableManager>
{
    private List<HittableObject> Hittables;

    protected override void Awake()
    {
        Hittables = new List<HittableObject>();
        base.Awake();
    }

    public override void OnMoveToNewBeat(ConductorSongInformation conductorSongInformation)
    {
        for(int index = Hittables.Count - 1; index >= 0; index--)
        {
            var hittable = Hittables[index];
            if ((int)conductorSongInformation.SongPositionInBeats > hittable.ShowUpBeat) //Do not move on the spawned beat
            {
                MoveHittable(hittable, hittable.MovePerBeat);
            }
        }
    }
    public void AddHittable(HittableObject hittable)
    {
        if(!Hittables.Contains(hittable)) Hittables.Add(hittable);
    }

    private void MoveHittable(HittableObject hittable, int amountOfPositions, bool isToMoveAhead = true)
    {
        int indexToMove = hittable.CurrentIndexInLane;

        for (int laneIndex = 0; laneIndex < hittable.LanesOccupation.Count; laneIndex++)
        {
            if (!hittable.LanesOccupation[laneIndex]) continue;

            indexToMove += amountOfPositions * (isToMoveAhead ? -1 : 1);
            if(indexToMove <= LevelManager.Instance.MinSlotPositionInLane(laneIndex) && isToMoveAhead)
            {
                bool wasDestroyed = TakeDamageDestroyIfNeeded(hittable, 1); //Fixed Damage for now
                if (wasDestroyed) return;

                indexToMove += LevelManager.Instance.FixLaneSlotIndexBoundaries(laneIndex, amountOfPositions + hittable.MoveBackAmountWhenDamaged);
            }

            hittable.CurrentIndexInLane = indexToMove;
            Vector3 newPosition = LevelManager.Instance.GetSlotPositionInLane(laneIndex, indexToMove);
            hittable.transform.position = newPosition;
        }   
    }

    private bool TakeDamageDestroyIfNeeded(HittableObject hittable, int damage)
    {
        hittable.CurrentDamageTaken += damage;
        if(hittable.CurrentDamageTaken >= hittable.MaxHitpoints)
        {
            Destroy(hittable.transform.gameObject);
            Hittables.Remove(hittable);

            return true;
        }

        return false;
    }
}
