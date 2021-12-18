using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public AudioSource sound;
    public Transform TrashBin;
    GameObject can;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            sound.Play();
            can = Instantiate(Resources.Load("Can") as GameObject, TrashBin);
            collision.GetComponent<PlayerHack>().SetDevice(can);
            BoxCollider2D[] collider2D = GetComponents<BoxCollider2D>();
            foreach(BoxCollider2D i in collider2D)
            {
                i.enabled = false;
            }
        }
    }
}
