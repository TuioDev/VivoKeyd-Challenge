using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Reference to the attack area game object from the editor
    [SerializeField] private GameObject attackArea;

    private SpriteRenderer attackSprite;

    // Boolean to know if the player is attacking
    private bool isAttacking = false;

    // *TEMPORARY*
    // This defines the amount of time between the attacks
    /// This will be linked with the rhythm in the future so the timing here is changing
    private float timeToAttack = 0.1f;

    // This will store the passed time, then reset if the player attacks
    private float timer = 0f;

    private void Start()
    {
        attackSprite = attackArea.GetComponent<SpriteRenderer>();
    }
    /// The ideal is that other classes don't need to have Update, but first making it work
    private void Update()
    {
        if (isAttacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0f;
                isAttacking = false;
                attackSprite.enabled = false;
            }
        }
    }

    public void Attack()
    {
        isAttacking = true;
        attackSprite.enabled = true;
    }
}
