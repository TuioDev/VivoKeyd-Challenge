using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInLanes : MonoBehaviour
{
    // Variable to know where the player is and an extra variable so that we don't need
    // to create another one inside Move() function that will be called every move
    private int playerCurrentLane;
    private int laneIndex;

    private void Start()
    {
        // The player will always start at the second lane
        playerCurrentLane = 1;
        this.transform.position = LaneInformation.GetPlayerLanePosition(playerCurrentLane);
    }

    // Move the player to the lane above
    public void Upward()
    {
        Move(1);
    }

    // Move the player to the lane below
    public void Downward()
    {
        Move(-1);
    }

    // Will move the player to the lane next
    private void Move(int playerNextIndex)
    {
        laneIndex = playerNextIndex + playerCurrentLane;
        playerCurrentLane = LaneIndexLimitation(laneIndex);
        Vector3 newPosition = LaneInformation.GetPlayerLanePosition(playerCurrentLane);
        this.transform.position = newPosition;
    }

    // *TEMPORARY*
    // One wy to clamp the lane index value because the Clamp fucntion is not working like we need
    // If we change the amount of lanes or create mechanics that blocks lanes,
    // THIS SHALL BE CHANGED
    private int LaneIndexLimitation(int lane)
    {
        if (lane < 0) return 0;
        if (lane > 3) return 3;
        return lane;
    }
}
