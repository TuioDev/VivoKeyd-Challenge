using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

[CreateAssetMenu(fileName = "CommandSO", menuName = "SO/Attack Command")]
public class AttackCommand : Command
{
    [SerializeField] private int X;
    [SerializeField] private int Y;

    public override void Execute()
    {
        PlayerManager.Instance.Move(new Point(X, Y));
    }
}
