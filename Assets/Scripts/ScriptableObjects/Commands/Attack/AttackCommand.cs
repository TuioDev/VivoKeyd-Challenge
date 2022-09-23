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
        Point currentPosition = new Point(); //Remove after the bellow condition is done
        if (StartFromPlayer)
        {
            //Set currentPosition with Player position
        }
        else
        {
            //Set currentPosition with Player position, but on the last slot of the lane
        }

        foreach (AttackDirectionCommand directionCommand in DirectionCommands)
        {
            currentPosition = directionCommand.MoveAndExecute(currentPosition, Damage);
        }
    }
}