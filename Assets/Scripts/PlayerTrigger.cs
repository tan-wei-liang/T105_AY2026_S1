using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private bool hasKey = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: Check if player touched the Key
        if (other.CompareTag("Key"))
        {
            // TODO: Set hasKey to true
            // TODO: Destroy the key object
        }

        // TODO: Check if player touched the Door
        else if (other.CompareTag("Door"))
        {
            // TODO: If player has key
            // open the door

            // TODO: Else
            // show message in Console
        }
    }
}