using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueByCollider : MonoBehaviour
{
    public DialogueTrigger trigger;
    public bool finish = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&!collision.isTrigger)
        {
            trigger.TriggerDialogue(this);
        }
    }

    public void FinishDialogue()
    {
        finish = true;
    }
}