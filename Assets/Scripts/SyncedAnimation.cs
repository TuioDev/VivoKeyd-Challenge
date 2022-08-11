using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncedAnimation : MonoBehaviour
{
    //The animator controller attached to this GameObject
    public Animator animator;

    //Records the animation state or animation that the Animator is currently in
    public AnimatorStateInfo animatorStateInfo;

    //Used to address the current state within the Animator using the Play() function
    public int currentState;

    public float beatsPerLoop;

    private int completedLoops = 0;

    private float loopPositionInBeats;

    // Start is called before the first frame update
    void Start()
    {
        //Load the animator attached to this object
        animator = GetComponent<Animator>();

        //Get the info about the current animator state
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //Convert the current state name to an integer hash for identification
        currentState = animatorStateInfo.fullPathHash;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate the loop position
        if (Conductor.Instance.songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
            completedLoops++;
        loopPositionInBeats = Conductor.Instance.songPositionInBeats - (completedLoops * beatsPerLoop);
        //Start playing the current animation from wherever the current conductor loop is
        animator.Play(currentState, -1, (loopPositionInBeats / beatsPerLoop)
                                            /*THIS VALUE IS THE POSITION OF THE ANIMATION
                                            BETWEEN 0 AND 1, FROM START TO END*/);
        //Set the speed to 0 so it will only change frames when you next update it
        animator.speed = 0;
    }
}
