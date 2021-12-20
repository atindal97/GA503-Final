using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeChange : MonoBehaviour
{

    public Slider slider;
    public Slider sliderMusic;
    public Slider sliderSFX;
    public AudioMixer mixer = null;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(changeMasterVolume);
        sliderMusic.onValueChanged.AddListener(changeMusicVolume);
        sliderSFX.onValueChanged.AddListener(changeSFXVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMasterVolume(float vol)
    {
        if (vol == slider.minValue)
        {
            mixer.SetFloat("MasterVol", -80);
        }
        else
        {
            mixer.SetFloat("MasterVol", vol);
        }
    }

    public void changeMusicVolume(float volMusic)
    {
        if (volMusic == sliderMusic.minValue)
        {
            mixer.SetFloat("MusicVol", -80);
        }
        else
        {
            mixer.SetFloat("MusicVol", volMusic);
        }
    }

    public void changeSFXVolume(float volSFX)
    {
        if (volSFX == sliderSFX.minValue)
        {
            mixer.SetFloat("SFXVol", -80);
        }
        else
        {
            mixer.SetFloat("SFXVol", volSFX);
        }
    }
}
