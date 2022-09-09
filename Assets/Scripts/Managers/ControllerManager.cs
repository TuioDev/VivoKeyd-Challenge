using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : Singleton<ControllerManager>
{
    // Reference of the player from the editor
    public GameObject objectThatMoves;

    // Commands that can be linked to different keys
    private Command buttonUp;
    private Command buttonDown;
    private Command buttonAttack;

    // *TEMPORARY VARIABLE*
    // THIS WILL BE LINKED WITH THE CONDUCTOR CLASS PROBABLY
    // Limiting the amout of moves that the player can perform in a amount of time

    private const float REPLAY_PAUSE_TIMER = 0.5f;

    private void Start()
    {
        buttonUp = new MoveUpInLaneCommand(objectThatMoves.GetComponent<MoveInLanes>());
        buttonDown = new MoveDownInLaneCommand(objectThatMoves.GetComponent<MoveInLanes>());
        buttonAttack = new AttackCommand(objectThatMoves.GetComponent<PlayerAttack>());
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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.L))
        {
            buttonAttack.Execute();
        }
    }
}
