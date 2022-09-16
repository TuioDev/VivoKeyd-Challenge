public abstract class ConductionDependentSingleton<T> : Singleton<T> where T : ConductionDependentSingleton<T>
{
    private void OnEnable()
    {
        if (Conductor.Instance != null)
        {
            Conductor.Instance.MovedToNewBeat += OnMoveToNewBeat;
        }
    }

    private void OnDisable()
    {
        if (Conductor.Instance != null)
        {
            Conductor.Instance.MovedToNewBeat -= OnMoveToNewBeat;
        }
    }

    abstract public void OnMoveToNewBeat(ConductorSongInformation conductorSongInformation);
}
