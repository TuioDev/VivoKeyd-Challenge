using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    // Reference of the player from the editor
    public MoveInLanes objectThatMoves;

    // Commands that can be linked to different keys
    private Command buttonUp;
    private Command buttonDown;

    // *TEMPORARY VARIABLE*
    // THIS WILL BE LINKED WITH THE CONDUCTOR CLASS PROBABLY
    // Limiting the amout of moves that the player can perform in a amount of time

    private const float REPLAY_PAUSE_TIMER = 0.5f;

    private void Start()
    {
        buttonUp = new MoveUpInLaneCommand(objectThatMoves);
        buttonDown = new MoveDownInLaneCommand(objectThatMoves);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            buttonUp.Execute();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            buttonDown.Execute();
        }
    }
}
