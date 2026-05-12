using UnityEngine;

public class PlayerChoice : MonoBehaviour
{    
	public int playerMove	= -1;
	public int round		= 0;
	public int maxRounds	= 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
		// TODO: Detect Rock / Paper / Scissors
		if (other.CompareTag("Rock"))
		{
			playerMove = 0;
		}
		else if (other.CompareTag("Paper"))
		{
			playerMove = 1;
		}
		else if (other.CompareTag("Scissors"))
		{
			playerMove = 2;
		}

		// TODO: Generate AI choice using Random.Range()
		int aiMove = Random.Range(0, 3);
		Debug.Log(aiMove);

		// Difference between playerMove and aiMove can be used to 
		// determine result of each round
		int difference	= playerMove - aiMove;

		// TODO: Compare player vs AI (Win / Lose / Draw)
		// Player: Rock (0),		AI: Rock (0),		Difference = 0
		// Player: Paper (1),		AI: Paper (1),		Difference = 0
		// Player: Scissors (2),	AI: Scissors (2),	Difference = 0
		if (difference == 0)
		{
			Debug.Log("Draw");
		}
		// Player: Rock (0),		AI: Scissors (2),	Difference = -2
		// Player: Paper (1),		AI: Rock (0),		Difference = 1
		// Player: Scissors (2),	AI: Paper (1),		Difference = 1
		else if (difference == 1 || difference == -2)
		{
			Debug.Log("Win");
		}
		// Player: Rock (0),		AI: Paper (1),		Difference = -1
		// Player: Paper (1),		AI: Scissors (2),	Difference = -1
		// Player: Scissors (2),	AI: Rock (0),		Difference = 2
		else
		{
			Debug.Log("Lose");
		}

		// TODO: Update round
		round++;

		// TODO: Display result using Debug.Log()
		if (round >= maxRounds)
		{
			Debug.Log("Game Over!");
		}
	}
}
