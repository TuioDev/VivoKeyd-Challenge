using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInLanes : MonoBehaviour
{
    private int currentLane;
    public void Upward()
    {
        
    }

    public void Downward()
    {

    }

    private void Move(int index)
    {
        LaneInformation.GetLanePosition(index);
    }
}
