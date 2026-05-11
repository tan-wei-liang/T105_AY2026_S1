using System.Collections;
using TMPro;
using UnityEngine;

public class WhileExample : MonoBehaviour
{
    [SerializeField]
    TMP_Text whileText      = null;
    [SerializeField]
    string tagToCompare     = "Player";

    [SerializeField]
    bool isUsingCoroutine   = false;
    bool isCoroutineStarted = false;
	[SerializeField]
	float coroutineInterval = 0.05f;
	string coroutineName	= "CoroutineUpdate";
	[SerializeField]
	bool isDebug			= false;

	float timer             = 0.0f;
    bool isInBoundaries     = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isUsingCoroutine)
        {
            StartCoroutine(coroutineName);
        }
    }

    // Update is called once per frame
    void Update()
	{
		if (isUsingCoroutine)
		{
			if (isCoroutineStarted)
			{
				return;
			}
			// Start coroutine if it has not started
			StartCoroutine(coroutineName);
			isCoroutineStarted	= true;
		}
		else
		{
			NonCoroutineUpdate();

			if (!isCoroutineStarted)
			{
				return;
			}
			// Stop coroutine if it has not stopped
			StopCoroutine(coroutineName);
			isCoroutineStarted = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(tagToCompare))
		{
			isInBoundaries = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag(tagToCompare))
		{
			isInBoundaries	= false;
		}
	}

    void NonCoroutineUpdate()
	{
		// Player is not in boundaries, no need to update
		if (!isInBoundaries)
		{
			return;
		}

		// update time player has spent in boundaries
		timer	+= Time.deltaTime;

		// whileText is not set up, no need to display
		if (whileText == null)
		{
			return;
		}

		UpdateWhileText();
		PrintDebugLog();
	}

	IEnumerator CoroutineUpdate()
    {
        while(true)
        {
			if(isInBoundaries)
			{
				timer += coroutineInterval;
				UpdateWhileText();
				PrintDebugLog();
			}
			yield return new WaitForSeconds(coroutineInterval);
		}
    }

	void UpdateWhileText()
	{
		// (int) will cast the float into int, thus
		// removing any numbers behind the decimal point
		// Casting is an act of converting data from one
		// type to another, may crash the program is the
		// resulting data type is not suitable.
		// Casting is used here to limit the precision of 
		// the float displayed.
		float truncatedTimer	= (int)(timer * 100) / 100.0f;
		whileText.text			= $"While Timer: {truncatedTimer}";
	}

	void PrintDebugLog()
	{
		if(!isDebug)
		{
			return;
		}

		if(isUsingCoroutine)
		{
			Debug.Log("Update in CoroutineUpdate()");
		}
        else
		{
			Debug.Log("Update in NonCoroutineUpdate()");
		}
	}
}
