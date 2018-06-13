using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTestClasses : MonoBehaviour {
    bool testMode = false;
    TestPlayerInput testPlayerInput;

	void Start () {
        // TODO read from config to see if test mode switched on	
        testPlayerInput = new TestPlayerInput();
	}
	
	void FixedUpdate () {
		if (testMode)
        {
            testPlayerInput.TriggerPlayerInput();
        }
	}
}
