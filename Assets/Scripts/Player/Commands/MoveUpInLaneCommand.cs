using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpInLaneCommand : Command
{
    private MoveInLanes moveInLanes;

    public MoveUpInLaneCommand(MoveInLanes moveInLanes)
    {
        this.moveInLanes = moveInLanes;
    }
    public override void Execute()
    {
        moveInLanes.Upward();
    }
}
