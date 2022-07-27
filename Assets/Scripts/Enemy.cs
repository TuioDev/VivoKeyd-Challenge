using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // When the Enemy hitbox is whithin attack range, this will be true and the player hit will succed
    [SerializeField] private bool canBePressed = false;

    // Which key to press
    [SerializeField] private KeyCode keyPressed;

    public float enemyVelocity = 3.0f;

    /// Cheking the note if it can be pressed here might be wrong
    /// Better try to move it to the player or the AttackArea
    void Update()
    {
        transform.Translate(Vector3.left * enemyVelocity * Time.deltaTime);
        
        /// This should not be here, the ControllerManager is responsible of the inputs,
        /// but it works for now
        if (Input.GetKeyDown(keyPressed)){
            if (canBePressed)
            {
                gameObject.SetActive(false);
            }
        }
    }

    /// When entering the hit zone there will be different values maybe?
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "AttackArea")
        {
            canBePressed = true;
        }
    }
    
    // If the note was withing range, but the player did not hit it, then we an put the damage
    // to the player here, or send a message if we use listeners
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "AttackArea")
        {
            canBePressed = false;
        }
    }
}
