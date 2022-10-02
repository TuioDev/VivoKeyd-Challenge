using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

[CreateAssetMenu(fileName = "CommandSO", menuName = "SO/Attack Command")]
public class AttackCommand : Command
{
    //When false start from end of lane
    [SerializeField] private bool StartFromPlayer = true;
    [SerializeField] private int Damage = 1;
    [SerializeField] private int PierceAmount = 0;
    [SerializeField] List<AttackDirectionCommand> DirectionCommands = new();
    public override void Execute()
    {
        Point currentPosition = PlayerManager.Instance.GetPlayerPositionReference();
        if (!StartFromPlayer)
        {
            currentPosition.X = LevelManager.Instance.MaxSlotPositionInLane(currentPosition.Y);
        }

        int damageCount = 0;

        foreach (AttackDirectionCommand directionCommand in DirectionCommands)
        {
            var result = directionCommand.MoveAndExecute(currentPosition, Damage);
            currentPosition = result.NewPosition;

            if (result.WasDamageApplied)
            {
                damageCount++;

                if (damageCount > PierceAmount)
                {
                    return;
                }
            }
        }
    }
}