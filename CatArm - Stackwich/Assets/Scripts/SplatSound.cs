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

	public AudioSource SFXAudio;
	/*
	public AudioSource goodSFX;
	public AudioSource perfectSFX;
	public AudioSource missSFX;
	public AudioSource inedibleSFX;
	public AudioSource goldSFX;
	*/

	public string placementType;

	// Start is called before the first frame update
	void Start()
	{
		placementType = " ";

		SFXAudio = GetComponent<AudioSource>();

		/*
		goodSFX.clip = goodSound;
		perfectSFX.clip = perfectSound;
		missSFX.clip = missSound;
		inedibleSFX.clip = inedibleSound;
		goldSFX.clip = goldSound;
		*/

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
				SFXAudio.clip = perfectSound;
				SFXAudio.Play();
				//perfectSFX.Play();
				break;

			case "Good":
				SFXAudio.clip = goodSound;
				SFXAudio.Play();
				//goodSFX.Play();
				break;

			case "Miss":
				SFXAudio.clip = missSound;
				SFXAudio.Play();
				//missSFX.Play();
				break;

			case "Inedible":
				SFXAudio.clip = inedibleSound;
				SFXAudio.Play();
				//inedibleSFX.Play();
				break;

			case "Golden":
				SFXAudio.clip = goldSound;
				SFXAudio.Play();
				//goldSFX.Play();
				break;


			default:
				break;
		}

	}





}
