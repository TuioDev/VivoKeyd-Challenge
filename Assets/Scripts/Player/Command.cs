using Baracuda.Monitoring;
using UnityEngine;

public abstract class Command : ScriptableObject
{
    public abstract void Execute();
}
