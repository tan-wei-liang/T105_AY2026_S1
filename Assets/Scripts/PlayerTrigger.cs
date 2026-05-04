using Unity.VisualScripting;
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
            hasKey  = true;
            // TODO: Destroy the key object
            // As PlayerTrigger is a component of Player,
            // other will refer to the object that the
            // player came in contact with in this frame
            Destroy(other.gameObject);
        }

        // TODO: Check if player touched the Door
        else if (other.CompareTag("Door"))
        {
            // TODO: If player has key
            // open the door
            if(hasKey)
            {
                Destroy(other.gameObject);
            }
            // TODO: Else
            // show message in Console
            else
            {
                Debug.Log("To open the door, you need a key!");
            }
        }
    }
}