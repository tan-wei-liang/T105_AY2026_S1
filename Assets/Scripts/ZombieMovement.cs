using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float lowestY;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		//move the zombie downwards over time
		transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
		//destroy the zombie if it goes below the screen
		if (transform.position.y < lowestY)
		{
			Destroy(gameObject);
		}
	}
}
