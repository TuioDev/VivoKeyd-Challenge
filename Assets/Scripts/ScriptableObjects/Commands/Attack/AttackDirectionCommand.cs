using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "CommandSO", menuName = "SO/Attack/Direction Command")]
public class AttackDirectionCommand : ScriptableObject
{
    [SerializeField] private MoveDirection Movement = MoveDirection.Right;
    [SerializeField] private bool ApplyDamage = true;

    public AttackDirectionCommandResult MoveAndExecute(Point currentPosition, int damage)
    {
        // currentPosition adiciona a direção
        switch (Movement)
        {
            case MoveDirection.Right:
                currentPosition.X += 1;
                break;
            case MoveDirection.Up:
                currentPosition.Y += 1;
                break;
            case MoveDirection.Down:
                currentPosition.Y -= 1;
                break;
            case MoveDirection.Left:
                currentPosition.X -= 1;
                break;
        }
        // SEE IF THIS IS RIGHT
        if (ApplyDamage)
        {
            bool wasDamageApplied = HittableManager.Instance.ApplyDamageIfPossible(currentPosition, damage);

            return new AttackDirectionCommandResult()
            {
                WasDamageApplied = wasDamageApplied,
                NewPosition = currentPosition,
            };
        }
        else
        {
            return new AttackDirectionCommandResult() { };
        }
        
    }
}

public record AttackDirectionCommandResult
{
    public bool WasDamageApplied;
    public Point NewPosition;
}
