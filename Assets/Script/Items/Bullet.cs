using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float Speed = 200f;
    [SerializeField]
    private int dps = 5;
    [SerializeField]
    private float second = 3f;

    private Rigidbody2D rb;    
    public string setType;
    void Start()
    {
        StartCoroutine(Timeset());
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed ;
     
    }
    IEnumerator Timeset()
    {
        yield return new WaitForSeconds(second);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.isTrigger == false)
        {
            if (hitObject.gameObject.CompareTag(setType))
            {
                MobFunda mobinfo = hitObject.gameObject.GetComponent<MobFunda>();
                if (mobinfo != null)
                {
                    mobinfo.Gethit(dps);
                    Destroy(gameObject);
                }
            }
            else if (hitObject.CompareTag("Wall") || hitObject.CompareTag("Door"))
            {
                Destroy(gameObject);
            }
        }

        else if (hitObject.gameObject.CompareTag("Missile"))
        {
            MobFunda mobinfo = hitObject.gameObject.GetComponent<MobFunda>();
            if (mobinfo != null)
            {
                mobinfo.Gethit(dps);
                Destroy(gameObject);
            }
        }

        
    }
}
