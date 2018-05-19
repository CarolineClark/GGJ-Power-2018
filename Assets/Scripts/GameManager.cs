using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private LevelManager levelManager;                       //Store a reference to our BoardManager which will set up the level.
    private int level = 0;                                  //Current level number, expressed in game as "Day 1".

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

	private void Start()
	{
        LevelEvent.Listen(UpdateLevel);
        DeathEvent.ListenForGameManagerDeathEvent(Die);
        levelManager = GetComponent<LevelManager>();
        InitGame();
	}

	void InitGame()
    {
        levelManager.SetupScene(level);
    }

    void UpdateLevel(Hashtable h) {
        level = LevelEvent.ReadCheckpoint(h);
        Debug.Log("updated level to: " + level);
    }

    void Die(Hashtable h) {
        Debug.Log("you died in GameManager");
        InitGame();
    }
}
