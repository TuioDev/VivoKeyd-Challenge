using Baracuda.Monitoring;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HittableObject : MonitoredObject
{
    public string GUID;
    public string HittableType;
    public string HittableName;
    public int MaxHitpoints;
    public int CurrentDamageTaken;
    public int DamageOnHit;
    public int ShowUpBeat;
    public int MovePerBeat;
    public int MoveBackAmountWhenDamaged;
    public int MoveBackAmountWhenDamaging;

    public List<bool> LanesOccupation = new(); // Y
    public int CurrentIndexInLane; // X

    public Transform transform;

    public override string ToString()
    {
        return GUID;
    }
}