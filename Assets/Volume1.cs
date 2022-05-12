using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume1 : MonoBehaviour
{
    [SerializeField] private AudioMixer myAudioMixer;

    public void SetVolume(float sliderValue) 
    {
        myAudioMixer.SetFloat("MasterVolume1", Mathf.Log10(sliderValue) * 20);
    }
}

