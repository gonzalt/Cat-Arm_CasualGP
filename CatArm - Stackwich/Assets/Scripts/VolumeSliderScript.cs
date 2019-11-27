using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderScript : MonoBehaviour
{


    public AudioMixer volMixer;

	//public float defSlider = 1.0f;


    public void SetLevel (float sliderValue)
    {
        volMixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue) * 20 );
    }


    void Start()
    {
		//this.gameObject.GetComponent<Slider>().value = volMixer.GetFloat("MusicVol", out 1.0f);
	}


    void Update()
    {
        
    }
}
