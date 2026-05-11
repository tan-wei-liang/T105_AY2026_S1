using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab   = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		//Step 7: Detect the SPACE Key
		if (Input.GetKeyDown(KeyCode.Space))
        {
			//Step 8: Add a Spawn Method, call the method
			SpawnEnemies();
        }
    }

	//Step 8: Add a Spawn Method, create the method
	void SpawnEnemies()
    {
		//Step 9: Add the For Loop
		for (int i = 0; i < 3; i++)
        {
			//Step 10: Create a Position for Each Enemy
			Vector3 position = new Vector3(i * 2, 0, 0);
			//Step 11: Spawn the Enemy
			Instantiate(enemyPrefab, position, Quaternion.identity);
		}
	}
}
