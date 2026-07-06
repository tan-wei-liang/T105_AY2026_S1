using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject zombiePrefab  = null;
	public float spawnTime          = 1f;
	public float spawnDelay         = 1f;
	public bool stopSpawning        = false;

	private float spawnY            = 5.8f;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		// Step 13, works the same as code shown in slides
		InvokeRepeating("SpawnZombie", spawnTime, spawnDelay);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SpawnZombie()
	{
		// random horizontal position
		float randomX = Random.Range(-3.3f, 3.3f);
		//create a spawn position
		Vector3 spawnpos = new Vector3(randomX, spawnY, 0f);

		//spawn zombie
		Instantiate(zombiePrefab, spawnpos, Quaternion.identity);

		//if stop spawning is true, stop InvokeRepeating() from calling SpawnZombie() again
		if (stopSpawning)
		{
			CancelInvoke("SpawnZombie");
		}
	}
}
