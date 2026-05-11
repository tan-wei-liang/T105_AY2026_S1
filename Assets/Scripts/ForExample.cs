using System.Collections;
using TMPro;
using UnityEngine;

public class ForExample : MonoBehaviour
{
    [SerializeField]
	KeyCode activationKey   = KeyCode.F;
    [SerializeField]
	KeyCode countKey        = KeyCode.G;
    [SerializeField]
    int count               = 0;
	[SerializeField]
	TMP_Text countText      = null;

	bool isActivating       = false;
    [SerializeField]
    float spawnInterval     = 0.5f;
    [SerializeField]
    GameObject spawnObject  = null;
    [SerializeField]
    float spawnOffSet       = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
	{
		UpdateCountText();
	}

    // Update is called once per frame
    void Update()
    {
        if (isActivating)
        {
            return;
        }

        if (Input.GetKeyDown(activationKey))
        {
            StartCoroutine("Activate");
		}

        if (Input.GetKeyDown(countKey))
        {
            count++;
			UpdateCountText();
		}
    }

    IEnumerator Activate()
    {
        isActivating    = true;
		for (int i = 0; i < count; i++)
		{
            // Randomise the spawn position
			Vector3 randSpawnLoc        = transform.position;
            randSpawnLoc.x              += spawnOffSet * Random.Range(-1.0f, 1.0f);
            // Spawn object at randSpawnLoc and add it as child of transform
            GameObject spawnInstance    = Instantiate(spawnObject, randSpawnLoc, Quaternion.identity, transform);
            yield return new WaitForSeconds(spawnInterval);
		}

        // reset variables
		count           = 0;
		isActivating    = false;
        UpdateCountText();
	}

    void UpdateCountText()
    {
		countText.text  = $"Count: {count}";
	}
}
