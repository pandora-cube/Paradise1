using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    [SerializeField]
    private GameObject Turrethead;       //터렛 모가지
    public GameObject target;
    public bool trace;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        trace = false;
    }

    private void OnTriggerStay2D(Collider2D collision)        //타깃 범위 이내일때
    {
        if (!collision.isTrigger)
            if (collision.gameObject == target)
            {
                StartCoroutine("TraceShoot");
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger)
            if (collision.gameObject == target)
            {
                StopCoroutine("TraceShoot");
                trace = false;
            }
    }
    private IEnumerator TraceShoot()                            //타깃 발사 AI코루틴
    {
        trace = true;
        Vector2 range = target.transform.position - transform.position;

        float angle = Mathf.Atan2(range.x, range.y) * Mathf.Rad2Deg;

        Turrethead.transform.rotation = Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z - angle);

        yield return new WaitForSeconds(0.2f);

        StartCoroutine("TraceShoot");
    }
}
