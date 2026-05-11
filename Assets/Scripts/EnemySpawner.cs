using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab   = null;
	[SerializeField]
	TMP_InputField xInputField		= null;
	[SerializeField]
	TMP_InputField yInputField		= null;

	int x	= 0;
	int y	= 0;
	GameObject container	= null;
	[SerializeField]
	Vector2 positionOffset	= Vector2.one;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		x	= int.Parse(xInputField.text);
		y	= int.Parse(yInputField.text);
		xInputField.onValueChanged.AddListener(OnGridSizeChanged);
		yInputField.onValueChanged.AddListener(OnGridSizeChanged);

		CreateSpawnContainer();
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
		float initialX	= (x - 1) * positionOffset.x * -0.5f;
		float initialY	= (y - 1) * positionOffset.y * -0.5f;
		//Step 9: Add the For Loop
		for (int i = 0; i < x; i++)
        {
			float posX = initialX + positionOffset.x * i;
			for (int j = 0; j < y; j++)
			{
				float posY = initialY + positionOffset.y * j;
				//Step 10: Create a Position for Each Enemy
				Vector3 position = new Vector3(posX, posY, 0);
				//Step 11: Spawn the Enemy
				Instantiate(enemyPrefab, position, Quaternion.identity, container.transform);
			}
		}
	}

	void OnGridSizeChanged(string newValue)
	{
		x	= int.Parse(xInputField.text);
		y	= int.Parse(yInputField.text);
	}

	public void ResetSpawns()
	{
		Destroy(container);
		CreateSpawnContainer();
	}

	void CreateSpawnContainer()
	{
		container	= Instantiate(new GameObject(), transform);
		container.name = "Container";
	}
}
