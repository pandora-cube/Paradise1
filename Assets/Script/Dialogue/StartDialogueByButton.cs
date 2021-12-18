using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueByButton : MonoBehaviour
{
    public Queue<GameObject> QueQuest = new Queue<GameObject>();
    private GameObject node;

    public void OnQuest(GameObject Quest)
    {
        QueQuest.Enqueue(Quest);
        Debug.Log("Quest Input! count :"+ QueQuest.Count.ToString());
        if(QueQuest.Count == 1)
        {
            TriggerQuest();
        }
    }
    public void TriggerQuest()
    {
        if(QueQuest.Count == 0)
        {
            Debug.LogError("퀘스트가 없습니다.");
            return;
        }
        node = QueQuest.Dequeue();
    }

    public void CallQuest()
    {
        DialogueTrigger dialogue = node.GetComponent<DialogueTrigger>();
        dialogue.TriggerDialogue();
    }
}
