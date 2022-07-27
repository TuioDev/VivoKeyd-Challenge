using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObject : ScriptableObject
{
    public string hittableType;
    public string hittableName;
    public int maxHitpoints;
    public int damageOnHit;
    public int showUpBeat;
    public int movePerBeat;
    public int moveBackAmountWhenDamaged;
    public int moveBackAmountWhenDamaging;
    public List<bool> lanesOccupation;
}
