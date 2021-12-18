using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public string Qpath;
    private StartDialogueByButton QuestLog;

    private void Start()
    {
        QuestLog = FindObjectOfType<StartDialogueByButton>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&!collision.isTrigger)
        {
            GameObject quest = Resources.Load(Qpath) as GameObject;
            Debug.Log("quest" + quest.name);
            QuestLog.OnQuest(Instantiate(quest, QuestLog.gameObject.transform));
            enabled = false;
        }
    }
}
