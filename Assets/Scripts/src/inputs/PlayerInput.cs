using UnityEngine;

public class PlayerInput : MonoBehaviour {
	
	public void Trigger() 
    {
        Vector2 move = new Vector2(
            Input.GetAxis(Constants.HORIZONTAL_AXIS), 
            Input.GetAxis(Constants.VERTICAL_AXIS)
        );
        PlayerMoveEvent.TriggerEvent(move);
	}
}
