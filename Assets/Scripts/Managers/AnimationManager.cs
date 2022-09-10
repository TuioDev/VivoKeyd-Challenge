using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : ConductionDependetSingleton<AnimationManager>
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
        animator = GetComponent<Animator>();
    }

    private int GetCurrentState()
    {
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return animatorStateInfo.fullPathHash;
    }

    public override void OnMoveToNewBeat(ConductorSongInformation conductorSongInformation)
    {
        //if (conductorSongInformation.SongPositionInBeats >= (completedLoops + 1) * beatsPerLoop) completedLoops++;

        //loopPositionInBeats = conductorSongInformation.SongPositionInBeats - (completedLoops * beatsPerLoop);
        ////Start playing the current animation from wherever the current conductor loop is
        ////THIS VALUE IS THE POSITION OF THE ANIMATION BETWEEN 0 AND 1, FROM START TO END
        //animator.Play(GetCurrentState(), -1, (loopPositionInBeats / beatsPerLoop));
        ////Set the speed to 0 so it will only change frames when you next update it
        //animator.speed = 0;
    }
}
