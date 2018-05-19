using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 cameraOffset;

	private Rigidbody2D rigidbody;
	private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;
    private Camera cameraMain;

    private GameObject torch;

    // to be worked out when you have spritesheets.
    private Animator animator;
    private Sprite leftSprite;
    private Sprite rightSprite;

	void Start () 
    {
        DeathEvent.ListenForPlayerDeathEvent(Die);
        DeathEvent.ListenForPlayerFallingEvent(DieByFalling);
        cameraMain = Camera.main;
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        // TODO: Get light child object
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

        FlipSpriteAndLightIfNeeded(move.x);
	}

    void FlipSpriteAndLightIfNeeded(float direction)
    {
        if (direction < 0) 
        {
            SetAnimation(true, false, 0);
        } 
        else if (direction > 0)
        {
            SetAnimation(false, true, 0);
        }
    }

    private void SetAnimation(bool left, bool right, float speed)
    {
        animator.SetBool(Constants.PLAYER_ANIMATION_LEFT, left);
        animator.SetBool(Constants.PLAYER_ANIMATION_RIGHT, right);
        //animator.SetFloat(Constants.PLAYER_ANIMATION_SPEED, speed);
    }

    private void Die(Hashtable h) 
    {
        DeathEvent.EmitForGameManager();
    }

    private void DieByFalling(Hashtable h)
    {
        PlayFallingDeathAnimation();
        DeathEvent.EmitForGameManager();
    }

    private void PlayFallingDeathAnimation() {
        Debug.Log("Playing falling death animation in player");
    }
}
