using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableBehaviour : MonoBehaviour
{
    public HittableObject HittableInformation { get => this.hittableInformation; private set => this.hittableInformation = value; }
    [SerializeField] private HittableObject hittableInformation;

    // When the Enemy hitbox is whithin attack range, this will be true and the player hit will succed
    [SerializeField] private bool canBePressed = false;

    // Which key to press
    [SerializeField] private KeyCode keyPressed;

    public Vector3 beginningPosition;
    public Vector3 endingPosition;

    private float interpolateTime = 0f;

    /// Cheking the note if it can be pressed here might be wrong
    /// Better try to move it to the player or the AttackArea
    void Update()
    {
        interpolateTime = InterpolateTime();
        InterpolatePosition();

        /// This should not be here, the ControllerManager is responsible of the inputs,
        /// but it works for now
        if (Input.GetKeyDown(keyPressed))
        {
            if (canBePressed)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetHittableInformation(HittableObject hittable)
    {
        HittableInformation.hittableType = hittable.hittableType;
        HittableInformation.hittableName = hittable.hittableName;
        HittableInformation.maxHitpoints = hittable.maxHitpoints;
        HittableInformation.damageOnHit = hittable.damageOnHit;
        HittableInformation.showUpBeat = hittable.showUpBeat;
        HittableInformation.movePerBeat = hittable.movePerBeat;
        HittableInformation.moveBackAmountWhenDamaged = hittable.moveBackAmountWhenDamaged;
        HittableInformation.moveBackAmountWhenDamaging = hittable.moveBackAmountWhenDamaging;
        hittable.lanesOccupation.ForEach(lane => HittableInformation.lanesOccupation.Add(lane));
    }

    private void InterpolatePosition()
    {
        transform.position = Vector2.Lerp(beginningPosition, endingPosition, interpolateTime - 1);
    }

    private float InterpolateTime()
    {
        return (Conductor.Instance.beatsSpawnOffset -
            (HittableInformation.showUpBeat - Conductor.Instance.songPositionInBeats)) / Conductor.Instance.beatsSpawnOffset;
    }

    /// When entering the hit zone there will be different values maybe?
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "AttackArea")
        {
            canBePressed = true;
        }
    }

    // If the note was withing range, but the player did not hit it, then we an put the damage
    // to the player here, or send a message if we use listeners
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "AttackArea")
        {
            canBePressed = false;
        }
    }
}
