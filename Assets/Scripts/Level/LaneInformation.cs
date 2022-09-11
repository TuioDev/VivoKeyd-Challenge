using System.Collections.Generic;
using UnityEngine;

public class LaneInformation : MonoBehaviour
{
    public bool IsBase;
    public GameObject Lane;
    public GameObject HittablesParent;
    public GameObject SlotsParent;
    public Transform PlayerSlotPosition;
    public List<Transform> SlotsPosition;
    public List<Transform> PrefabSlots;
}