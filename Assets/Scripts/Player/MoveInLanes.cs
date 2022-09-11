using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInLanes : MonoBehaviour
{
    [SerializeField] private int UdwardLane = -1;
    [SerializeField] private int DownwardLane = 1;

    private int playerCurrentLane = 0;

    public void Upward()
    {
        Move(UdwardLane);
    }

    public void Downward()
    {
        Move(DownwardLane);
    }

    private void Move(int playerNextIndex)
    {
        playerCurrentLane = LaneIndexLimitation(playerNextIndex + playerCurrentLane);
        Vector3 newPosition = LevelManager.Instance.PlayerPositionPerLane.GetValueOrDefault(playerCurrentLane);
        this.transform.position = newPosition;
    }

    private int LaneIndexLimitation(int lane)
    {
        var min = LevelManager.Instance.MinLaneIndex;
        var max = LevelManager.Instance.MaxLaneIndex;

        return lane < min ? min : lane > max ? max : lane;
    }
}
