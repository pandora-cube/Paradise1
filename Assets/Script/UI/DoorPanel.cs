using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorPanel : MonoBehaviour
{
    public GameObject door = null;
    private DoorController controller = null;
    private HacksysFunda hacksys = null;

    public Image image;
    public Toggle toggle;

    private void Start()
    {
        controller = door.GetComponent<DoorController>();
        image.sprite = door.GetComponent<SpriteRenderer>().sprite;
        hacksys = door.GetComponent<HacksysFunda>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !toggle.isOn)
        {
            QuitPanel();
        }
    }

    public void Controllerset()
    {
        if(toggle.isOn)
        {
            controller.Door(true);
        }
        else if(!toggle.isOn)
        {
            controller.Door(false);
        }
    }

    public void QuitPanel()
    {
        hacksys.HackOff();
        SlotController slotController = GetComponentInParent<SlotController>();
        slotController.slotPanel.Remove(slotController.panelnode);
        slotController.panelnode = slotController.slotPanel.First;
        Destroy(gameObject);
    }
}
