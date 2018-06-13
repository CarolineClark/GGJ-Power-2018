using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour {
    public GameObject other;
	
	// Update is called once per frame
	void Update () {
        transform.position = other.transform.position;
	}
}
