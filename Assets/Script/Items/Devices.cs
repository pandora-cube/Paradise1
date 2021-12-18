using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devices : MonoBehaviour
{
    public int Ram;
    public int RamCount = 0;
    private int UsedRam;
    public DialogueTrigger trigger;
    public GameObject Call;

    private void Start()
    {
        UsedRam = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {            
            collision.gameObject.GetComponent<PlayerHack>().SetDevice(gameObject);
            if(trigger != null) trigger.TriggerDialogue();
            Call.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public int RestRam()
    {
        return Ram - UsedRam;
    }

    public void OfferRam(int cache)
    {
        UsedRam += cache;
    }

    public void GetRamItem()
    {
        RamCount += 1;
        Ram += 128;
    }
}