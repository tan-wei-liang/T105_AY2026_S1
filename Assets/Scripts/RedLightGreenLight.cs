using UnityEngine;

public class RedLightGreenLight : MonoBehaviour
{
    public PlayerMovement player;

    public SpriteRenderer trafficLightRenderer;
    public Sprite redLightSprite;
    public Sprite greenLightSprite;

    public float greenTime = 3f;
    public float redTime = 2f;

    private bool greenLight = true;
    private bool playerDied = false;
    private float timer = 0f;

    void Update()
    {
        if (playerDied)
            return;

        timer += Time.deltaTime;

		// TODO:
		// If the light is green and the timer reaches greenTime,
		// switch to red and reset the timer
		if (greenLight && timer >= greenTime)
		{
			greenLight = false;
			timer = 0f;
		}

		// TODO:
		// Else if the light is red and the timer reaches redTime,
		// switch to green and reset the timer
		else if (!greenLight && timer >= redTime)
		{
			greenLight = true;
			timer = 0f;
		}

		// TODO:
		// If the light is red and the player is moving,
		// make the player lose
		if (!greenLight && player.isMoving)
		{
			playerDied = true;
			player.GameOver();
            Debug.Log("You lose! Restart game to play again!");
		}

		UpdateTrafficLightVisual();
    }

    void UpdateTrafficLightVisual()
    {
        if (greenLight)
        {
            trafficLightRenderer.sprite = greenLightSprite;
        }
        else
        {
            trafficLightRenderer.sprite = redLightSprite;
        }
    }
}