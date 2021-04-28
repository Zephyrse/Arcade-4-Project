using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Misc_SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicScript", Mathf.Log10(sliderValue) * 20);
    }
    
}
