using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    //Value of the music beat in beats per minute
    public float beatTempo;

    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        //Converts bpm into beat per second
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        //Change this with GAME PAUSE
        if (!hasStarted)
        {
            hasStarted = true;
        }
        else
        {
            //The notes will move based on the bps
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
