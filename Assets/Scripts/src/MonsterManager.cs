using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {
    public Transform[] spawnPoints;
    public GameObject monster;
    private Dictionary<GameObject, Vector2> spawnedMonsters;

	public void Awake()
	{
        spawnedMonsters = new Dictionary<GameObject, Vector2>();
        Spawn(); 
	}

	public void ResetPositions() {
        foreach (KeyValuePair<GameObject, Vector2> entry in spawnedMonsters)
        {
            entry.Key.transform.position = entry.Value;
        }
    }

    void Spawn() {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Vector2 chosenSpawnPoint = spawnPoints[spawnPointIndex].position;
        GameObject spawned = Instantiate(monster, chosenSpawnPoint, spawnPoints[spawnPointIndex].rotation);
        spawnedMonsters.Add(spawned, chosenSpawnPoint);
    }
}
