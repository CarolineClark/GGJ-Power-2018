using UnityEngine;

public class Monster : MonoBehaviour
{
    public float monsterSpeed;

    private GameObject player;
    private BoxCollider2D collider2D;
    private Rigidbody2D rigidbody2D;

    private bool monsterInLightCollider;

    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag(Constants.PLAYER_TAG);
    }

	private void Update()
	{
        if (monsterInLightCollider) {
            MonsterWalksToPlayer();
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains(Constants.TORCH_TAG))
        {
            Debug.Log("monster saw you!");
            EmitMonsterSawLightEvent();
            monsterInLightCollider = true;
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.tag.Contains(Constants.TORCH_TAG))
        {
            Debug.Log("monster lost you!");
            monsterInLightCollider = false;
        }
	}

	private void EmitMonsterSawLightEvent() {
        Vector2 distance = player.transform.position - transform.position;
        MonsterEvent.EmitMonsterSawLightEvent(distance.magnitude);
    }

    private void MonsterWalksToPlayer() {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rigidbody2D.velocity = monsterSpeed * direction;
    }
}
