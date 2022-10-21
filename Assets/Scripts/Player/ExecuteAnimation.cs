using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteAnimation : MonoBehaviour
{
    [SerializeField] private CommandManager Manager;
    
    // Start is called before the first frame update
    void Start()
    {
        // Manager = GameObject.FindObjectOfType<ControllerManager>();
    }

    public void ExecuteAttackAnimation()
    {
        Manager.AttackTrigger(false);
    }
}
