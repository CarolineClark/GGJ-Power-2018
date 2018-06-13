using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private PlayerManager playerManager;
    private MonsterManager monsterManager;
    private EnvironmentManager environmentManager;

	void Awake () {
        playerManager = GetComponent<PlayerManager>();
        monsterManager = GetComponent<MonsterManager>();
        environmentManager = GetComponent<EnvironmentManager>();
	}

    public void SetupScene(int level) 
    {
        playerManager.ResetPlayerPosition();
        monsterManager.ResetPositions();
        environmentManager.ResetEnvironment();   
    }
}
