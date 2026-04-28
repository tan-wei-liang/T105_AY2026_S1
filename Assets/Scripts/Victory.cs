using UnityEngine;

public class Victory : MonoBehaviour
{
    public PlayerMovement player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GameOver();
            Debug.Log("You Win!");
        }
    }
}
