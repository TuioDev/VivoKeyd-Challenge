using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    //Trying to implement the note system based on TIME

    //TEST
    public delegate void EventHandler(int parametro1, int parametro2);
    List<int> list = new List<int>();

    public EventHandler[] EH = new EventHandler[10];
    // Start is called before the first frame update
    void Awake()
    {
        EH[0] = HandleMyEvent;
    }

    void Start()
    {
        foreach(EventHandler eh in EH)
        {
            if(eh != null)
            {
                eh(0, 0);
            }
        }
        list.RemoveAll(p => p > 0);
        
    }

    void HandleMyEvent(int parametro1, int parametro2)
    {
        Debug.Log("Event Called");
    }
}
