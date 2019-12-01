using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyMainMenuManagementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void LoadEndlessLevel()
	{
		SceneManager.LoadScene("EndlessLevel");
	}
	
	public void LoadOptions()
	{
		SceneManager.LoadScene("Options");
	}
	
	public void LoadCredits()
	{
		SceneManager.LoadScene("Credits");
	}

	public void LoadHowTo()
	{
		SceneManager.LoadScene("HowTo");
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void QuitTheGame()
	{
		Application.Quit();
	}




}
