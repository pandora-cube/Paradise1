using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private bool open;
    public GameObject door;
    void Start()
    {
        open = false;
    }

    private void FixedUpdate()
    {
        if (open == true)
            door.SetActive(false);
        else if (open == false)
            door.SetActive(true);
    }

    public void Door(bool i)
    {
        if (i == true)
            open = true;
        else if(i == false)
            open = false;
    }
}
