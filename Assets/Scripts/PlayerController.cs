using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 cameraOffset;
    public Vector3 torchOffset;

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

        torch = transform.Find("Torch").gameObject;
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
        bool left = direction < 0;
        bool right = direction > 0;
        if (left || right) {
            SetAnimation(left, 0);
            SetTorchPosition(left);
        }
    }

    private void SetAnimation(bool left, float speed)
    {
        animator.SetBool(Constants.PLAYER_ANIMATION_LEFT, left);
        animator.SetBool(Constants.PLAYER_ANIMATION_RIGHT, !left);
        //animator.SetFloat(Constants.PLAYER_ANIMATION_SPEED, speed);
    }

    private void SetTorchPosition(bool left) {
        int multiplier = left ? -1 : 1;
        float x = transform.position.x + multiplier * torchOffset.x;
        float y = transform.position.y + torchOffset.y;
        float z = transform.position.z + torchOffset.z;
        torch.transform.position = new Vector3(x, y, z);
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
