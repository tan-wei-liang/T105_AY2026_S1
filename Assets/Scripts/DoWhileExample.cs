using System.Collections;
using TMPro;
using UnityEngine;

public class DoWhileExample : MonoBehaviour
{
	[SerializeField] 
    Transform transformToScale  = null;
    [SerializeField]
    float scaledSize            = 2.0f;
    [SerializeField]
    float initialSize           = 1.0f;
    [SerializeField]
    float scaleSpeed            = -0.05f;
    [SerializeField]
	KeyCode activationKey       = KeyCode.E;
    [SerializeField]
    float coroutineInterval     = 0.01f;
    [SerializeField]
    TMP_Text doWhileText        = null;

    string coroutineName        = "DoWhileCoroutine";
    bool isCoroutineRunning     = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// Ensure that scaledSize, initialSize are positive
		scaledSize                      = Mathf.Abs(scaledSize);
		initialSize                     = Mathf.Abs(initialSize);
        // Ensure that scaleSpeed is negative
		scaleSpeed                      = -Mathf.Abs(scaleSpeed);
		// Ensure that transform is set to initialSize
		transformToScale.localScale     = Vector3.one * initialSize;
        UpdateDoWhileText();
	}

	// Update is called once per frame
	void Update()
    {
        // Start coroutine if activationKey is pressed and
        // transform has returned to initialSize
        if(Input.GetKey(activationKey) && transformToScale.localScale.x == initialSize)
        {
            StartCoroutine(coroutineName);
            isCoroutineRunning  = true;
		}

        // Transform is still scaling down
        if(isCoroutineRunning)
        {
            return;
        }

        // Transform has already been reset to initialSize
        if(transformToScale.localScale.x == initialSize)
        {
            return;
        }

		// Reset transform to initialSize
		transformToScale.localScale = Vector3.one * initialSize;
        UpdateDoWhileText();
	}

    IEnumerator DoWhileCoroutine()
	{
		transformToScale.localScale         = Vector3.one * scaledSize;
        do
        {
            Vector3 newSize                 = transformToScale.localScale + Vector3.one * scaleSpeed * coroutineInterval;
			transformToScale.localScale     = newSize;
            UpdateDoWhileText();
			yield return new WaitForSeconds(coroutineInterval);
        }
        while (transformToScale.localScale.x > initialSize);
        isCoroutineRunning = false;
	}

    void UpdateDoWhileText()
	{
		float truncatedScale = (int)(transformToScale.localScale.x * 100) / 100.0f;
		doWhileText.text = $"Object scale: {truncatedScale}";
	}
}
