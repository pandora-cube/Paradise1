using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public DialogueTrigger trigger;
    public float delay;
    public bool Useful;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Useful)
        {
            if(trigger != null) trigger.TriggerDialogue();
            collision.gameObject.GetComponent<GunShoot>().SetWeapon(gameObject);
            gameObject.SetActive(false);
        }
    }
}