using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 cameraOffset;

	private Rigidbody2D rigidbody;
	private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;
    private Camera cameraMain;

    // to be worked out when you have spritesheets.
    private Animator animator;
    private Sprite leftSprite;
    private Sprite rightSprite;

	void Start () 
    {
        DeathEvent.ListenForPlayerDeathEvent(Die);
        cameraMain = Camera.main;
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
        cameraMain.transform.position = rigidbody.transform.position - cameraOffset;
	}

	void FixedUpdate () 
    {
		Vector2 move = Vector2.zero;
        move.x = Input.GetAxis (Constants.HORIZONTAL_AXIS);
        move.y = Input.GetAxis (Constants.VERTICAL_AXIS);
		rigidbody.velocity = move;

        // this might just be handled by the animator?
        FlipSpriteIfNeeded(move.x);
	}

    void FlipSpriteIfNeeded(float direction)
    {
        //if (direction < 0 && spriteRenderer.sprite.Equals(rightSprite)) 
        //{
        //    spriteRenderer.sprite = leftSprite;
        //} 
        //else if (direction < 0 && spriteRenderer.sprite.Equals(leftSprite)) 
        //{
        //    spriteRenderer.sprite = rightSprite;
        //}
    }

    private void SetAnimation(bool left, bool right, float speed)
    {
        animator.SetBool(Constants.PLAYER_ANIMATION_LEFT, left);
        animator.SetBool(Constants.PLAYER_ANIMATION_RIGHT, right);
        animator.SetFloat(Constants.PLAYER_ANIMATION_SPEED, speed);
    }

    private void Die(Hashtable h) {
        PlayDeathAnimation();
        DeathEvent.EmitForGameManager();
    }

    private void PlayDeathAnimation() {
        Debug.Log("Playing death animation in player");
    }
}
