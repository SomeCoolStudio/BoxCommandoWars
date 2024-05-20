using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private float defaultMusicVolume;


    private void Start()
    {
        SetVolumeLevel(defaultMusicVolume);
    }

    public void SetVolumeLevel(float sliderValue)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void ResetVolume()
    {
        SetVolumeLevel(defaultMusicVolume);
    }
}
