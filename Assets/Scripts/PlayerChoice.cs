using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.Unicode;

public class PlayerChoice : MonoBehaviour
{
    public int playerMove	= -1;
	public int round		= 0;
	public int maxRounds	= 3;

	public int win	= 0;
	public int lose = 0;
	public int draw = 0;

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
		Debug.Log($"AI Move: {aiMove}");

		// TODO: Compare player vs AI (Win / Lose / Draw)
		if (playerMove == aiMove)
		{
			Debug.Log($"Round {round}: Draw");
			draw++;
		}
		// Player: Rock (0),		AI: Paper (1),		Difference = -1
		// Player: Paper (1),		AI: Scissors (2),	Difference = -1
		// Player: Scissors (2),	AI: Rock (0),		Difference = 2
		else if (playerMove - aiMove == -1 || playerMove - aiMove == 2)
		{
			Debug.Log($"Round {round}: Lose");
			lose++;
		}
		// Player: Rock (0),		AI: Scissors (2),	Difference = -2
		// Player: Paper (1),		AI: Rock (0),		Difference = 1
		// Player: Scissors (2),	AI: Paper (1),		Difference = 1
		else
		{
			Debug.Log($"Round {round}: Win");
			win++;
		}

		// TODO: Update round
		round++;

		// TODO: Display result using Debug.Log()
		if (round >= maxRounds)
		{
			Debug.Log("Game Over!");
			Debug.Log($"Results: {win} Win(s), {lose} Lose(s), {draw} Draw(s) ");
		}
	}
}
