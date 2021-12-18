using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public void SetVolume(float vol)
    {
        AudioMixer.SetFloat("volume", vol);
    }

    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
}
