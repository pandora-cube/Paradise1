using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public PlayerHack player;

    private void Update()
    {
        if(player.GetDevice() != null)
        {
            if(player.GetDevice().name == "Can")
                SceneManager.LoadScene(2);
        }
    }
}
