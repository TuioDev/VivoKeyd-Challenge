using System.Collections.Generic;

[System.Serializable]
public class HittableObject
{
    public string HittableType;
    public string HittableName;
    public int MaxHitpoints;
    public int DamageOnHit;
    public int ShowUpBeat;
    public int CurrentPositionBeat;
    public int MovePerBeat;
    public int MoveBackAmountWhenDamaged;
    public int MoveBackAmountWhenDamaging;
    public List<bool> LanesOccupation = new();
}