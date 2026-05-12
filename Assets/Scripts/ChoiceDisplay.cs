using UnityEngine;

public class ChoiceDisplay : MonoBehaviour
{
	GameObject currentChoice			= null;
	public GameObject choiceUnknown		= null;
	public GameObject choiceRock		= null;
	public GameObject choicePaper		= null;
	public GameObject choiceScissors	= null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		currentChoice	= choiceUnknown;
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateChoice(int choice)
    {
		// hide previous choice
		currentChoice.SetActive(false);

		if (choice == 0)
		{
			currentChoice = choiceRock;
		}
		else if (choice == 1)
		{
			currentChoice = choicePaper;
		}
		else if (choice == 2)
		{
			currentChoice = choiceScissors;
		}

		// show current choice
		currentChoice.SetActive(true);
	}

	public void ResetChoice()
	{
		currentChoice.SetActive(false);
		currentChoice	= choiceUnknown;
		currentChoice.SetActive(true);
	}

	public void HideChoice()
	{
		currentChoice.SetActive(false);
	}
}
