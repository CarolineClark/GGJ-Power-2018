using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPitCollider : MonoBehaviour
{

    private Collider2D collider;

    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(Constants.PLAYER_TAG))
        {
            DeathEvent.EmitPlayerFalling();
        }
    }
}
