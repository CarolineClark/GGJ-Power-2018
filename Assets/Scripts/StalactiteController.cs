using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteController : MonoBehaviour {
    private BoxCollider2D collider2D;
    private Animator animator;
    private bool activated = false;

	void Start () {
        collider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (!activated && other.tag.Equals(Constants.PLAYER_TAG)) {
            PlayAnimationAndFall();
        }
	}

    private void PlayAnimationAndFall() {
        animator.Play(Constants.STALACTITE_WOBBLE_ANIM);
    }
}
