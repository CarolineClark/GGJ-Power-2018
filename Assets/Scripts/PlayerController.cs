using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 cameraOffset;
    public Vector3 torchOffset;

    public Material leftMaterial;
    public Material rightMaterial;

	private Rigidbody2D rigidbody;
	private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;
    private Camera cameraMain;

    private GameObject torch;

    // to be worked out when you have spritesheets.
    private Animator animator;
    private Sprite leftSprite;
    private Sprite rightSprite;

    private bool left = false;

	void Start () 
    {
        DeathEvent.ListenForPlayerDeathEvent(Die);
        DeathEvent.ListenForPlayerFallingEvent(DieByFalling);
        cameraMain = Camera.main;
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        torch = GameObject.FindWithTag(Constants.TORCH_TAG);
        SetDirection();
	}

	private void Update()
	{
        cameraMain.transform.position = rigidbody.transform.position - cameraOffset;
        SetDirection();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag.Equals(Constants.MONSTER_TAG)) {
            DieByMonster();
        }
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
        if (System.Math.Abs(direction) > 0.01) {
            left = direction < 0;    
        }
    }

    private void SetDirection() {
        SetAnimation(0);
        SetTorchPosition();
    }

    private void SetAnimation(float speed)
    {
        animator.SetBool(Constants.PLAYER_ANIMATION_LEFT, left);
        animator.SetBool(Constants.PLAYER_ANIMATION_RIGHT, !left);
        //animator.SetFloat(Constants.PLAYER_ANIMATION_SPEED, speed);
    }

    private void SetTorchPosition() {
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

    private void DieByMonster()
    {
        Debug.Log("the monster killed you!");
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

    private void TransitionMaterialLeftToRight() {
        spriteRenderer.material.Lerp(leftMaterial, rightMaterial, Time.deltaTime);
    }

    private void TransitionMaterialRightToLeft()
    {
        spriteRenderer.material.Lerp(rightMaterial, leftMaterial, Time.deltaTime);
    }
}
