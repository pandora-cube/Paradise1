using UnityEngine;

public class Tomas : MonoBehaviour
{
    public DialogueTrigger[] triggers = new DialogueTrigger[9];
    public GameObject Toma;
    public GameObject Dosan;
    private ConsoleController console;
    private GameController GameController;
    public GameObject device;

    private void Start()
    {
        console = FindObjectOfType<ConsoleController>();
        GameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            if (!console.OnDial && collision.CompareTag("Player"))
            {

                switch (console.DialStack)
                {
                    case 1:
                        triggers[0].TriggerDialogue();
                        break;
                    case 2:
                        triggers[1].TriggerDialogue();
                        break;
                    case 3:
                        
                        triggers[2].TriggerDialogue();
                        break;
                    case 4:
                        triggers[3].TriggerDialogue();
                        break;
                    case 5:
                        
                        triggers[4].TriggerDialogue();
                        break;
                    case 6:
                        Toma.transform.localScale = new Vector3(-1, 1, 1);
                        triggers[5].TriggerDialogue();                        
                        break;
                    case 7:
                        triggers[6].TriggerDialogue();
                        break;
                    case 8:
                        triggers[7].TriggerDialogue();                        
                        break;
                    case 9:                        
                        triggers[8].TriggerDialogue();                        
                        break;
                    case 10:
                        triggers[9].TriggerDialogue();
                        break;
                    case 11:
                        triggers[10].TriggerDialogue();
                        break;
                    case 12:
                        triggers[11].TriggerDialogue();
                        device.SetActive(true);
                        break;
                    case 13:
                        triggers[12].TriggerDialogue();
                        GameController.StartFirst();
                        break;
                    case 14:
                        triggers[13].TriggerDialogue();
                        gameObject.SetActive(false);
                        break;
                }
            }
        }
    }
}
