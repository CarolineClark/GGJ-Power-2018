using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rigidbody;
	private BoxCollider2D collider;

	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D>();
	}
	
	void FixedUpdate () {
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis ("Horizontal");
		move.y = Input.GetAxis ("Vertical");
		rigidbody.velocity = move;
	}
}
