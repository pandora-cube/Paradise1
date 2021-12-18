using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public ConsoleController console;
    public DialogueTrigger trigger;

    private void Start()
    {
        trigger.TriggerDialogue();
    }
}
