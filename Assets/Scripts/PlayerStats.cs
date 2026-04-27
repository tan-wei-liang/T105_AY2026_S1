using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public string playerName	= "Nova";
	public int health			= 100;
	public float rotationSpeed	= 0.0f;
	public float size			= 1.0f;
	public bool aliveState		= true;

	public float rotationSpeedDelta	= 0.0f;
	public Vector3 scaleDelta		= Vector3.zero;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		transform.localScale	= new Vector3(size, size, 1);

		Debug.Log("Player: " + playerName);
		Debug.Log("Health: " + health);
	}


	// Update is called once per frame
	void Update()
	{
		// Change rotation speed based on rotation speed delta
		// causing object to rotate faster or slower
		rotationSpeed	+= rotationSpeedDelta * Time.deltaTime;
		transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

		// Change localScale based on scale delta
		// causing object to shrink or grow in size
		Vector3 newScale		= transform.localScale + scaleDelta * Time.deltaTime;
		transform.localScale	= newScale;

		// Prints a debug log using variables
		Debug.Log($"{playerName} is rotating at {rotationSpeed} and is now scaled to {newScale}");
	}
}
