using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneInformation : MonoBehaviour
{
    // All lanes information should be stored here

    // We pass all the PlayerLanePos objects to get the reference for the position
    // This reference is just to the player
    /// If the enemies change lane then this have to englobe everyone that moves lanes
    [SerializeField] private List<Transform> lanesReferences;

    // We need this static variable to be able to pass the information to the static method
    private static List<Vector3> lanesVectors = new List<Vector3>();

    private void Awake()
    {
        // Checking if the list is not null
        /// Can add a form to get all the information to prevent bugs if the list is null
        if (lanesReferences != null)
        {
            // Passing the position of each transform from the normal list to the static one
            foreach (Transform t in lanesReferences)
            {
                lanesVectors.Add(t.position);
            }
        }
    }

    // We get the player position and check if he is going to a valid positions
    public static Vector3 GetPlayerLanePosition(int laneIndex)
    {
        return lanesVectors[laneIndex];
    }
}
