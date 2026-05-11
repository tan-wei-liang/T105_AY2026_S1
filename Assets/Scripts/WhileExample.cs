using TMPro;
using UnityEngine;

public class WhileExample : MonoBehaviour
{
    [SerializeField]
    TMP_Text whileText  = null;
    [SerializeField]
    string tagToCompare = "Player";
    float timer         = 0.0f;
    bool isInBoundaries = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player is not in boundaries, no need to update
        if(!isInBoundaries)
        {
            return;
        }

        // update time player has spent in boundaries
        timer += Time.deltaTime;

        // whileText is not set up, no need to display
        if(whileText == null)
        {
            return;
        }

        // (int) will cast the float into int, thus
        // removing any numbers behind the decimal point
        // Casting is an act of converting data from one
        // type to another, may crash the program is the
        // resulting data type is not suitable.
        // Casting is used here to limit the precision of 
        // the float displayed.
        float truncatedTimer = (int)(timer * 100) / 100.0f ;
		whileText.text  = $"While Timer: {truncatedTimer}";
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag(tagToCompare))
        {
            isInBoundaries = true;
        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag(tagToCompare))
		{
			isInBoundaries = false;
		}
	}
}
