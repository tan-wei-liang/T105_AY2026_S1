using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
	public TMP_Text scoreTxt    = null;
	public static int score     = 0;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Update the UI text every frame
		scoreTxt.text = "Score: " + score;
	}
}
