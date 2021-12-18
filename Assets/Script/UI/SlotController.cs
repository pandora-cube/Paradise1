using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public LinkedList<GameObject> slotPanel = new LinkedList<GameObject>();
    public LinkedListNode<GameObject> panelnode;

    private void Update()
    {
        if (slotPanel.Count != 0)
        {
            panelnode.Value.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                panelnode.Value.SetActive(false);
                if (panelnode != slotPanel.First)
                {
                    panelnode.Previous.Value.SetActive(true);
                    panelnode = panelnode.Previous;
                }
                else
                {
                    slotPanel.Last.Value.SetActive(true);
                    panelnode = slotPanel.Last;
                }
            }

            else if (Input.GetKeyDown(KeyCode.E))
            {
                panelnode.Value.SetActive(false);
                if (panelnode != slotPanel.Last)
                {
                    panelnode.Next.Value.SetActive(true);
                    panelnode = panelnode.Next;
                }
                else
                {
                    slotPanel.First.Value.SetActive(true);
                    panelnode = slotPanel.First;
                }
            }
        }
    }
    public GameObject GetNewSlot(Slot newSlot)
    {
        GameObject slotUI = Instantiate(newSlot.panel, transform);      
        foreach(GameObject i in slotPanel)
        {
            i.SetActive(false);
        }
        slotPanel.AddLast(slotUI);
        panelnode = slotPanel.Last;
        return slotUI;
    }
}
