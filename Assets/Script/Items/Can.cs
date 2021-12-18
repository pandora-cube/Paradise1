using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public DialogueTrigger dialogue;
    private ConsoleController console;
    private GameController controller;

    private void Start()
    {
        console = FindObjectOfType<ConsoleController>();
        controller = FindObjectOfType<GameController>();
        dialogue.TriggerDialogue();
    }

    private void Update()
    {
        if(!console.OnDial&&console.DialStack==2)
        {
            if(Input.GetMouseButtonDown(1))
            {
                controller.LoadNextScene();
            }
        }
    }
}
