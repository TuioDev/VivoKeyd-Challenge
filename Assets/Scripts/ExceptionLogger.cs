using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExceptionLogger : MonoBehaviour
{
    //Internal reference to stream writer object
    private StreamWriter SW;

    //Filename to assign log
    public string LogFileName = "log.txt";

    // Start is called before the first frame update
    void Start()
    {
        //Make persistent
        DontDestroyOnLoad(gameObject);

        //Create string writer object
        SW = new StreamWriter(Application.persistentDataPath + "/" + LogFileName);

        Debug.Log(Application.persistentDataPath + "/" + LogFileName);
    }

    //Register for exception listening, and log exceptions
    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    //Unregister for exception listening
    void OnDisable()
    {
        Application.logMessageReceived -= null;
    }

    //Log exception to a text file
    void HandleLog(string logString, string stackTrace, LogType type)
    {
        //If an exception or error, then log to file
        if(type == LogType.Exception || type == LogType.Error)
        {
            SW.WriteLine("\nLogged at: " + System.DateTime.Now.ToString() +
                "\n - Log Desc: " + logString +
                "\n - Trace: " + stackTrace + 
                "\n - Type: " + type.ToString());
        }
    }

    //Called when object is destroyed
    void OnDestroy()
    {
        //Close file
        SW.Close();
    }

}
