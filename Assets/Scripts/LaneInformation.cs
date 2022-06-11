using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneInformation : MonoBehaviour
{
    // All lanes information should be store here
    [SerializeField] private static Transform[] lanes;
    
    public static Vector3 GetLanePosition(int index)
    {
        if(index > 0 || index <= lanes.Length)
        {
            return lanes[index-1].position;
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("Wrong index value.");
        }
    }   
}
