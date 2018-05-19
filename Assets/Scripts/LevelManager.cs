using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private PlayerManager playerManager;
    private EnemyManager enemyManager;
    private EnvironmentManager environmentManager;

	void Start () {
        playerManager = GetComponent<PlayerManager>();
        enemyManager = GetComponent<EnemyManager>();
        environmentManager = GetComponent<EnvironmentManager>();
	}

    public void SetupScene(int level) 
    {
        playerManager.ResetPlayerPosition();
        enemyManager.ResetEnemyPositions();
        environmentManager.ResetEnvironment();   
    }
}
