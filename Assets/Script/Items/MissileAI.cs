using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAI : MonoBehaviour
{
    [SerializeField]
    private float Speed = 130;
    [SerializeField]
    private int dps = 70;
    [SerializeField]
    private float second = 5f;

    private Rigidbody2D rb;
    [SerializeField]
    private GameObject target;
    public string setType;

    private void Start()
    {
        setType = "Player";
        target = GameObject.FindGameObjectWithTag(setType);
        rb = gameObject.GetComponent<Rigidbody2D>();    
        StartCoroutine(Timeset());
    }

    IEnumerator Timeset()
    {
        Vector2 range = gameObject.transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(range.x, range.y) * Mathf.Rad2Deg;
        rb.transform.rotation = Quaternion.Euler(0, 0, rb.transform.rotation.eulerAngles.z - angle);
        rb.velocity = transform.up * Speed;
        yield return new WaitForSeconds(0.5f);
        second -= 0.5f;
        if (second <= 0)
            Destroy(gameObject);
        StartCoroutine(Timeset());
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

            else if(hitObject.gameObject.CompareTag("Wall")||hitObject.gameObject.CompareTag("Ground")||hitObject.gameObject.CompareTag("Door"))
            {
                Destroy(gameObject);
            }
        }
    }
}
