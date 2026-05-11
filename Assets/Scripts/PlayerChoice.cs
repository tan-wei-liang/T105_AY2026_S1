using UnityEngine;

public class PlayerChoice : MonoBehaviour
{
    public int playerMove = -1;

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

		// TODO: Compare player vs AI (Win / Lose / Draw)

		// TODO: Update round

		// TODO: Display result using Debug.Log()
	}
}
