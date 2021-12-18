using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string Explain;
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<ConsoleController>().StartDialogue(dialogue);
    }

    public void TriggerDialogue(StartDialogueByCollider dialogueByCollider)
    {
        FindObjectOfType<ConsoleController>().StartDialogue(dialogue,dialogueByCollider);
    }
}
