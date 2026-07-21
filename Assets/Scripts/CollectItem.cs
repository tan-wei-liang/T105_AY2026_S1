using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            // Use this instead as FindFirstObjectByType is marked as obselete.
            // There will be only 1 GameUI so function will always return the same GameUI.
            FindAnyObjectByType<GameUI>().AddScore();
            Destroy(collision.gameObject);
        }   
    }
}
