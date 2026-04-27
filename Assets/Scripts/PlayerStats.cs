using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public string playerName = "Nova";
	public int health = 100;
	public float rotationSpeed = 0.0f;
	public float size = 1.0f;
	public bool aliveState = true;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		transform.localScale = new Vector3(size, size, 1);

		Debug.Log("Player: " + playerName);
		Debug.Log("Health: " + health);
	}


	// Update is called once per frame
	void Update()
	{

	}
}
