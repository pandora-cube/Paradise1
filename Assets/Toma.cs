using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toma : MonoBehaviour
{
    void Update()
    {
        if (gameObject.GetComponent<StartDialogueByCollider>().finish)
        {
            GameController controller = GameObject.FindObjectOfType<GameController>();
            controller.LoadNextScene();
        }
    }
}
