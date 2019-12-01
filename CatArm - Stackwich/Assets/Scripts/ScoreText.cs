using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text;

	public int goodScore = 1;
	public int perfectScore = 3;

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        GameManager.OnCubeSpawned += GameManager_OnCubeSpawned;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawned -= GameManager_OnCubeSpawned;
    }

    private void GameManager_OnCubeSpawned()
    {

		/*
		if (placeType = "Good")
		{
			score = score + goodScore;
		}
		else if (placeType = "Perfect")
		{
			score = score + PerfectScore;
		}
		*/

		//score++;
        //text.text = "Score: " + score;
    }



	public void ChangeScore(string placeType)
	{

		if (placeType == "Good")
		{
			score = score + goodScore;
		}
		else if (placeType == "Perfect")
		{
			score = score + perfectScore;
		}


		text.text = "Score: " + score;



	}



}
