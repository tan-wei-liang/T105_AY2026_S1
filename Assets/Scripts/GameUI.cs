using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TMP_Text scoreText   = null;
    int score                   = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score++;
        scoreText.text  = $"Score: {score}";
    }
}
