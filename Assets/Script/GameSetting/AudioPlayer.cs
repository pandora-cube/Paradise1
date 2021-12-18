using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource sound;

    public void BGMStart()
    {
        sound.Play();
        sound.loop = true;
        sound.Pause();
    }

    public void BGMVolumeSet(int vol)
    {
        sound.volume = vol;
    }

    public void BGMOff()
    {
        sound.Stop();
    }
}
