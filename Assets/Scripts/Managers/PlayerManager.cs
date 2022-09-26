using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : ConductionDependentSingleton<PlayerManager>
{
    // Movement variables
    [SerializeField] private GameObject PlayerReference;
    // Player initial value is (0, 0) so if we want to set a initial
    // position, THIS IS THE VARIABLE!
    [SerializeField] private Point PlayerPositionReference;

    // Attack varibles
    [SerializeField] private GameObject PlayerAttackArea;
    private SpriteRenderer AttackSprite;
    private bool IsAttacking = false;
    private float Timer = 0f;
    // This could be synced with the beat duration?
    private float AttackDuration = 0.1f;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        AttackSprite = PlayerAttackArea.GetComponent<SpriteRenderer>();
    }
    public override void OnMoveToNewBeat(ConductorSongInformation conductorSongInformation)
    {
        ExecuteMoveCommand();
    }

    // Move functions
    public void Move(Point playerTranslate)
    {
        PlayerPositionReference.X += playerTranslate.X;
        PlayerPositionReference.Y += playerTranslate.Y;

        PlayerReference.transform.position = LevelManager.Instance.GetPlayerPositionInLane(PlayerPositionReference.Y);
    }

    private void ExecuteMoveCommand()
    {
        Command command = ControllerManager.Instance.GetNextCommand();
        if (command != null)
        {
            command.Execute();
        }
    }
    // Attack functions
    public void Attack()
    {
        IsAttacking = true;
        StartCoroutine(AttackAnimation());
    }

    private IEnumerator AttackAnimation()
    {
        AttackSprite.enabled = true;
        yield return new WaitForSeconds(AttackDuration);
        AttackSprite.enabled = false;
        IsAttacking = false;
    }
}
