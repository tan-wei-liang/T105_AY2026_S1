using TMPro;
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
	
	[SerializeField]
	TMP_Text aiChoiceText	= null;
	[SerializeField]
	TMP_Text resultText		= null;
	[SerializeField]
	TMP_Text winCountText	= null;
	[SerializeField]
	TMP_Text loseCountText	= null;
	[SerializeField]
	TMP_Text drawCountText	= null;

	Vector2 initialPosition = Vector2.zero;

	void Start()
	{
		initialPosition	= transform.position;
	}

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
		if (aiChoiceText != null)
		{
			switch(aiMove)
			{
				case 0:
					aiChoiceText.text = "AI Choice: Rock";
					break;
				case 1:
					aiChoiceText.text = "AI Choice: Paper";
					break;
				case 2:
					aiChoiceText.text = "AI Choice: Scissors";
					break;
				default:
					aiChoiceText.text = "AI Choice: E R R O R !";
					break;
			}
		}

		// TODO: Compare player vs AI (Win / Lose / Draw)
		if (playerMove == aiMove)
		{
			Debug.Log($"Round {round}: Draw");
			draw++;
			resultText.text		= "Result: Draw";
			drawCountText.text	= draw.ToString();
		}
		// Player: Rock (0),		AI: Paper (1),		Difference = -1
		// Player: Paper (1),		AI: Scissors (2),	Difference = -1
		// Player: Scissors (2),	AI: Rock (0),		Difference = 2
		else if (playerMove - aiMove == -1 || playerMove - aiMove == 2)
		{
			Debug.Log($"Round {round}: Lose");
			lose++;
			resultText.text		= "Result: Lose";
			loseCountText.text	= lose.ToString();
		}
		// Player: Rock (0),		AI: Scissors (2),	Difference = -2
		// Player: Paper (1),		AI: Rock (0),		Difference = 1
		// Player: Scissors (2),	AI: Paper (1),		Difference = 1
		else
		{
			Debug.Log($"Round {round}: Win");
			win++;
			resultText.text		= "Result: Win";
			winCountText.text	= win.ToString();
		}

		// TODO: Update round
		round++;
		// reset position
		transform.position	= initialPosition;


		// TODO: Display result using Debug.Log()
		if (round >= maxRounds)
		{
			Debug.Log("Game Over!");
			Debug.Log($"Results: {win} Win(s), {lose} Lose(s), {draw} Draw(s) ");
		}
	}
}
