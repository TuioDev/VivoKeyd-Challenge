using Baracuda.Monitoring;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            MonitoringSystems.UI.Visible = !MonitoringSystems.UI.Visible;
        }

        if(GameManager.Instance.GetCurrentGameState() == GameState.PlayingLevel)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                CommandManager.Instance.EnqueueUpwardCommand();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                CommandManager.Instance.EnqueueDownwardCommand();
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.L))
            {
                CommandManager.Instance.AttackTrigger();
            }
        }
    }
}
