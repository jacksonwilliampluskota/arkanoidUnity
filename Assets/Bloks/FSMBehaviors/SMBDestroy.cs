using UnityEngine;
using System.Collections;

public class SMBDestroy : StateMachineBehaviour
{

    public float DelayTime;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Destroy(animator.gameObject, DelayTime);
	}

}
