using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoseScoreScript : MonoBehaviour
{
	private int score;
	private TextMeshProUGUI textObject;

	public GameObject gameScore;

	public GameObject losingScoreObject;
	public Text losingScore;

	public GameObject gameplayCanvas;


	void OnEnable()
	{
		textObject = gameScore.GetComponent<TMPro.TextMeshProUGUI>();

		losingScore = losingScoreObject.GetComponent<Text>();

		losingScore.text = textObject.text;

		gameplayCanvas.SetActive(false);

	}


	
}
