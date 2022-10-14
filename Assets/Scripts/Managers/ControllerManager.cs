using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : Singleton<ControllerManager>
{
    // MaxCommands guarantees that the player can only store 1 move, so he can replace a wrong input before the beat
    [SerializeField] private int MaxCommands = 1;
    [SerializeField] private Command MoveUpward;
    [SerializeField] private Command MoveDownward;
    [SerializeField] private Command Attack;

    [SerializeField] private LinkedList<Command> CommandQueue;
    [SerializeField] private Animator PlayerAnimator;

    protected override void Awake()
    {
        CommandQueue = new LinkedList<Command>(); 
        base.Awake();
    }
    private void Update()
    {
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
            AttackTrigger(true);
        }
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
    public void ExecuteCommandOffBeat(Command command)
    {
        command.Execute();
    }
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
    public void AttackTrigger(bool value)
    {
        PlayerAnimator.SetBool("Attack", value);
        ExecuteCommandOffBeat(Attack);
    }
}
