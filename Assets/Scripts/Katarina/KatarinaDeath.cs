using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaDeath : StateMachineBehaviour {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		var katarina = Katarina.instance;
        katarina.GetComponent<BoxCollider2D>().enabled = false;
        katarina.GetComponent<KatarinaMovement>().enabled = false;
        katarina.GetComponent<KatarinaJump>().enabled = false;
        katarina.GetComponent<KatarinaShunpo>().enabled = false;
        katarina.GetComponentInChildren<KatarinaFlurry>().enabled = false;
        katarina.GetComponent<Rigidbody2D>().gravityScale = 0;
        katarina.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
}
