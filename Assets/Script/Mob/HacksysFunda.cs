using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacksysFunda : MonoBehaviour
{
    public bool isHacked;   //해킹 당한 여부
    [SerializeField]
    private int cache;       //램 사용량
    private SlotController slot;
    [System.NonSerialized]
    public GameObject slotPanel;
    
    private GameObject Icon;

    private void Start()
    {
        isHacked = false;
        slot = FindObjectOfType<SlotController>();
    }

    public void HackOn(Devices device)
    {
        isHacked = true;
        device.OfferRam(cache);
        Slot newSlot = new Slot(gameObject);
        slotPanel = slot.GetNewSlot(newSlot);
        Icon = Instantiate(Resources.Load("UI/Hack") as GameObject, transform);
    }

    public void HackOff()
    {
        isHacked = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerHack>().GetDevice().GetComponent<Devices>().OfferRam(-cache);
        Destroy(Icon);
    }
    public int getCache()
    {
        return cache;
    }
}