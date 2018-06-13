using UnityEngine;

public class InputHandler : MonoBehaviour {
    public bool testMode = false;
    TestPlayerInput testPlayerInput;
    PlayerInput playerInput;

    void Start()
    {  
        testPlayerInput = new TestPlayerInput();
        playerInput = new PlayerInput();
    }

    void FixedUpdate()
    {
        if (testMode)
        {
            RunFixedUpdateTestClasses();
        }
        else
        {
            RunFixedUpdatePlayerClasses();
        }
    }

    void RunFixedUpdateTestClasses()
    {
        testPlayerInput.Trigger();
    }

    void RunFixedUpdatePlayerClasses()
    {
        playerInput.Trigger();
    }
}
