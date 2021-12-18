using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBGM : AudioPlayer
{
    private void Start()
    {
        BGMStart();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&!collision.isTrigger)
        {
            sound.UnPause();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            sound.Pause();
        }
    }
}
