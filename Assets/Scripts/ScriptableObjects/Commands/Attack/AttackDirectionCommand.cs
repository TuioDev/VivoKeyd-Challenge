using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "CommandSO", menuName = "SO/Attack/Direction Command")]
public class AttackDirectionCommand : ScriptableObject
{
    [SerializeField] MoveDirection Movement = MoveDirection.Right;
    [SerializeField] bool ApplyDamage = true;

    public Point MoveAndExecute(Point currentPosition, int damage)
    {
        //Add the Movement to currentPosition
        HittableManager.Instance.ApplyDamageIfPossible(currentPosition, damage);
        return currentPosition;
    }
}
