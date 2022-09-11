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
        playerCurrentLane = LevelManager.Instance.FixLaneIndexBoundaries(playerNextIndex + playerCurrentLane);
        this.transform.position = LevelManager.Instance.GetPlayerPositionInLane(playerCurrentLane);
    }
}
