using System.Collections.Generic;

[System.Serializable]
public class HittableObject
{
    public string hittableType;
    public string hittableName;
    public int maxHitpoints;
    public int damageOnHit;
    public int showUpBeat;
    public int movePerBeat;
    public int moveBackAmountWhenDamaged;
    public int moveBackAmountWhenDamaging;
    public List<bool> lanesOccupation = new List<bool>();
}