using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slot
{    
    public GameObject gameObject;
    public GameObject panel;

    public Slot(GameObject obj)
    {
        gameObject = obj;

        if(gameObject.CompareTag("Monster"))
        {
            panel = Resources.Load("UI/Robot") as GameObject;
            panel.GetComponent<RobotPanel>().robo = gameObject;
            gameObject.GetComponent<MonsterAI>().enabled = false;
        }

        else if(gameObject.CompareTag("Turret"))
        {
            panel = Resources.Load("UI/Turret") as GameObject;
            panel.GetComponent<TurretPanel>().turret = gameObject;
            gameObject.GetComponent<TurretAI>().target = null;
            gameObject.GetComponent<TurretAI>().enabled = false;
        }

        else if(gameObject.CompareTag("Door"))
        {
            panel = Resources.Load("UI/ShutDoor") as GameObject;
            panel.GetComponent<DoorPanel>().door = gameObject;
        }
    }
}
