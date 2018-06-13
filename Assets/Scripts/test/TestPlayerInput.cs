using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerInput {
	
	public void TriggerPlayerInput() {
        PlayerMoveEvent.TriggerEvent(new Vector2(1, 0));
	}
}
