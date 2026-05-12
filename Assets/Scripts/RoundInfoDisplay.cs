using TMPro;
using UnityEngine;

public class RoundInfoDisplay : MonoBehaviour
{
	public TMP_Text roundText			= null;
	public GameObject playerUnknown     = null;
	public GameObject playerRock        = null;
	public GameObject playerPaper       = null;
	public GameObject playerScissors    = null;
	public TMP_Text resultText			= null;
	public GameObject aiUnknown		    = null;
	public GameObject aiRock            = null;
	public GameObject aiPaper           = null;
	public GameObject aiScissors        = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDisplay(int round, int playerChoice, int aiChoice, int result)
	{
		roundText.text = $"{round}:";

		if (playerChoice == 0)
		{
			playerRock.SetActive(true);
		}
		else if (playerChoice == 1)
		{
			playerPaper.SetActive(true);
		}
		else if (playerChoice == 2)
		{
			playerScissors.SetActive(true);
		}

		if (aiChoice == 0)
		{
			aiRock.SetActive(true);
		}
		else if (aiChoice == 1)
		{
			aiPaper.SetActive(true);
		}
		else if (aiChoice == 2)
		{
			aiScissors.SetActive(true);
		}

		if (result == 0)
		{
			resultText.text	= "Draw";
		}
		else if (result == 1)
		{
			resultText.text = "Win";
		}
		else if (result == 2)
		{
			resultText.text = "Lose";
		}
	}
}
