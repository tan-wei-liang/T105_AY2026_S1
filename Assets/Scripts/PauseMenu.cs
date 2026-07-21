using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel    = null;
    bool isPaused                   = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

	private void PauseGame()
	{
        pausePanel.SetActive(true);
        Time.timeScale  = 0.0f;
        isPaused        = true;
	}

	public void ResumeGame()
	{
        pausePanel.SetActive(false);
        Time.timeScale  = 1.0f;
        isPaused        = false;
	}

    public void RestartGame()
    {
        Time.timeScale = 1.0f;  //ensure game is not paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
