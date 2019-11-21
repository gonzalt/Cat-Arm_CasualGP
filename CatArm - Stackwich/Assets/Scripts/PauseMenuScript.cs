using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{


    public bool gameIsPaused = false;

    public GameObject pauseMenuUI;

	public GameObject pauseButton;


	private bool gameStarted;

	// Start is called before the first frame update
	void Start()
    {
		gameStarted = false;
	}

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

		if (Input.GetButtonDown("Fire1"))
		{
			if (gameStarted == false)
			{
				enablePause();
			}
		}



	}


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
		pauseButton.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
		pauseButton.SetActive(false);
		Time.timeScale = 0f;
        gameIsPaused = true;
    }


	private void enablePause()
	{
		pauseButton.SetActive(true);
		gameStarted = true;
	}



	public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Loading Menu...");
    }

}
