using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{
    private PlayerAttack playerAttack;

    public AttackCommand(PlayerAttack playerAttack)
    {
        this.playerAttack = playerAttack;
    }

    public override void Execute()
    {
        playerAttack.Attack();
    }
}
