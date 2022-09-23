using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : Singleton<ControllerManager>
{
    // Commands that can be linked to different keys
    //private Command ButtonUp;
    //private Command ButtonDown;
    //private Command ButtonAttack;
    [SerializeField] private int MaxCommands = 1;
    [SerializeField] private Command MoveUpward;
    [SerializeField] private Command MoveDownward;

    // *TEMPORARY VARIABLE*
    // THIS WILL BE LINKED WITH THE CONDUCTOR CLASS PROBABLY
    // Limiting the amout of moves that the player can perform in a amount of time

    //private const float REPLAY_PAUSE_TIMER = 0.5f;

    [SerializeField] private LinkedList<Command> CommandQueue;

    protected override void Awake()
    {
        CommandQueue = new LinkedList<Command>(); 
        base.Awake();
    }
    private void Start()
    {
        //ButtonUp = new MoveUpInLaneCommand(ObjectThatMoves.GetComponent<MoveInLanes>());
        //ButtonDown = new MoveDownInLaneCommand(ObjectThatMoves.GetComponent<MoveInLanes>());
        //ButtonAttack = new AttackCommand(ObjectThatMoves.GetComponent<PlayerAttack>());

        // Now what do i put here to get commands...
        // Maybe a list of commands and populate from editor?
    }

    private void Update()
    {
        // Check the beat and dequeue?


        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            EnqueueCommand(MoveUpward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            EnqueueCommand(MoveDownward);
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.L))
        {
            //CommandQueue.Enqueue(ButtonAttack);
        }

        // Check if it is on the beat
        // Dequeue everything
    }
    public void EnqueueCommand(Command command)
    {
        if(CommandQueue.Count >= MaxCommands)
        {
            CommandQueue.RemoveLast();
        }
        CommandQueue.AddLast(command);
        //Debug.Log($@"Command: {command.name}; Count before: {CommandQueue.Count}");
    }
    // :)
    //private void ExecuteCommandQueueOnBeat()
    //{
    //    while(CommandQueue.Count > 0)
    //    {
    //        CommandQueue.Dequeue();
    //    }
    //}


    public Command GetNextCommand()
    {
        if (CommandQueue.Count > 0)
        {
            var firstCommmand = CommandQueue.First.Value;
            CommandQueue.RemoveFirst();
            //Debug.Log($@"Current command: {firstCommmand.name}; Next command: {CommandQueue.First?.Value.name}; Count after: {CommandQueue.Count}");
            return firstCommmand;
        }
        return null;
    }
}
