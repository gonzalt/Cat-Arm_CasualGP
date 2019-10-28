using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatSound : MonoBehaviour
{
	public AudioClip goodSound;
	public AudioClip perfectSound;
	public AudioClip missSound;
	public AudioClip inedibleSound;
	public AudioClip goldSound;

	public AudioSource goodSFX;
	public AudioSource perfectSFX;
	public AudioSource missSFX;
	public AudioSource inedibleSFX;
	public AudioSource goldSFX;

	public string placementType;

	// Start is called before the first frame update
	void Start()
	{
		placementType = " ";

		goodSFX.clip = goodSound;
		perfectSFX.clip = perfectSound;
		missSFX.clip = missSound;
		inedibleSFX.clip = inedibleSound;
		goldSFX.clip = goldSound;

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void PlayPlacementSFX(string placement)
	{

		switch (placement)
		{

			case "Perfect":
				perfectSFX.Play();
				break;

			case "Good":
				goodSFX.Play();
				break;

			case "Miss":
				missSFX.Play();
				break;

			case "Inedible":
				inedibleSFX.Play();
				break;

			case "Golden":
				goldSFX.Play();
				break;


			default:
				break;
		}

	}





}
