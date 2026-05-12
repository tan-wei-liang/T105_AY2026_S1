using UnityEngine;

public class PlayerChoice : MonoBehaviour
{    
	public int playerMove	= -1;
	public int round		= 0;
	public int maxRounds	= 3;

	public int win	= 0;
	public int lose = 0;
	public int draw = 0;

	// Variable to store Player's moves from round 0 to maxRound
	int playerMoves	= 0;
	// Variable to store AI's moves from round 0 to maxRound
	int aiMoves		= 0;

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
		Debug.Log($"Player chose {MoveToString(playerMove)}.");

		// TODO: Generate AI choice using Random.Range()
		int aiMove = Random.Range(0, 3);
		Debug.Log($"AI chose {MoveToString(aiMove)}.");

		// Difference between playerMove and aiMove can be used to 
		// determine result of each round
		int difference	= playerMove - aiMove;

		// TODO: Compare player vs AI (Win / Lose / Draw)
		// Player: Rock (0),		AI: Rock (0),		Difference = 0
		// Player: Paper (1),		AI: Paper (1),		Difference = 0
		// Player: Scissors (2),	AI: Scissors (2),	Difference = 0
		if (difference == 0)
		{
			Debug.Log($"Round {round}: Draw");
			draw++;

		}
		// Player: Rock (0),		AI: Scissors (2),	Difference = -2
		// Player: Paper (1),		AI: Rock (0),		Difference = 1
		// Player: Scissors (2),	AI: Paper (1),		Difference = 1
		else if (difference == 1 || difference == -2)
		{
			Debug.Log($"Round {round}: Win");
			win++;
		}
		// Player: Rock (0),		AI: Paper (1),		Difference = -1
		// Player: Paper (1),		AI: Scissors (2),	Difference = -1
		// Player: Scissors (2),	AI: Rock (0),		Difference = 2
		else
		{
			Debug.Log($"Round {round}: Lose");
			lose++;
		}

		// Store Player and AI moves
		/* 
		 * ------------------Explanation of code below------------------
		 * Idea: Store moves as ones, tens, hundreds, etc
		 * Round one is stored as ones, round two is stored as tens, etc
		 * Example: playerMoves = 201;
		 * Player played Paper in round 0, Rock in round 1, Scissors in round 2
		 * 
		 * Code:
		 * Mathf.Pow(10.0f, round) returns 10 to the power of round, i.e. 1, 10, 100, ...
		 * (int) will cast the result from Mathf.Pow(10.0f, round) from float to int,
		 * in other words, float value is converted to int value
		*/
		int roundMultiplier	= (int)Mathf.Pow(10.0f, round);
		playerMoves			+= playerMove * roundMultiplier;
		aiMoves				+= aiMove * roundMultiplier;

		// TODO: Update round
		round++;

		// TODO: Display result using Debug.Log()
		if (round >= maxRounds)
		{
			Debug.Log("Game Over!");
			Debug.Log($"Results: {win} Win(s), {lose} Lose(s), {draw} Draw(s) ");

			// Display choices made in each round using for loop
			for(int i = 0; i < maxRounds; i++)
			{
				// playerMoves % 10 will return the remainder of playerMoves when divided by 10
				// e.g. 94 % 10 = 4
				string playerChoice = MoveToString(playerMoves % 10);
				string aiChoice		= MoveToString(aiMoves % 10);
				Debug.Log($"Round {i}: Player chose {playerChoice} and AI chose {aiChoice}.");

				// Remove displayed choices
				// int data type can only contain whole numbers
				// When an int is divived by 10, the result will usually be a number with a
				// decimal point and values after the decimal point are truncated, thus removing
				// the the displayed choices for round i
				playerMoves /= 10;
				aiMoves		/= 10;
			}
			// reset round so that player can play again
			round	= 0;
		}

	}

	// Converts playerMove and aiMove into Rock, Paper, or Scissors
	string MoveToString(int moveInt)
	{
		string moveString	= "ERROR";
		if (moveInt == 0)
		{
			moveString		= "Rock";
		}
		else if (moveInt == 1)
		{
			moveString		= "Paper";
		}
		else if (moveInt == 2)
		{
			moveString		= "Scissors";
		}
		return moveString;
	}
}
