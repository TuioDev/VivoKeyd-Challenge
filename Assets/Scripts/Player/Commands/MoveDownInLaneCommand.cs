using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownInLaneCommand : Command
{
    private MoveInLanes moveInLanes;

    public MoveDownInLaneCommand(MoveInLanes moveInLanes)
    {
        this.moveInLanes = moveInLanes;
    }
    public override void Execute()
    {
        moveInLanes.Downward();
    }
}
