using Baracuda.Monitoring;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }
    protected virtual void Awake()
    {
        this.RegisterMonitor();

        if (Instance == null)
        {
            Instance = (T)this;
        }
        else
        {
            Debug.LogError("Got a second instance of the class " + this.GetType());
        }
    }
    protected virtual void OnDestroy()
    {
        this.UnregisterMonitor();
    }
}
