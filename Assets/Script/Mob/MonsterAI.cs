using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : Base
{
    private GameObject target;
    private Vector2 BasePos;
    [SerializeField]
    private float RoutineTime = 2f;
    public bool trace;
    private MobFunda Mob;
    private HacksysFunda Hack;
    private Rigidbody2D rb;

    Direction direction;

    private void Start()
    {
        BasePos = transform.position;
        BasePos.x += 0.5f;
        Mob = gameObject.GetComponent<MobFunda>();
        Hack = gameObject.GetComponent<HacksysFunda>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        trace = false;
        StartCoroutine("ChangeMove");
    }

    private void FixedUpdate()
    {
        Around_AI();
    }

    void Around_AI()
    {
        if (trace)
        {
            if (target.transform.position.x < transform.position.x)
                direction = Direction.LEFT;
            else if (target.transform.position.x > transform.position.x)
                direction = Direction.RIGHT;

        }

        if (direction == Direction.RIGHT)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector2(Mob.Speed, 0f);
        }
        else if (direction == Direction.LEFT)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = new Vector2(-Mob.Speed, 0f);
        }
    }

    IEnumerator ChangeMove()
    {
        if (transform.position.x < BasePos.x)
            direction = Direction.RIGHT;
        else if (transform.position.x > BasePos.x)
            direction = Direction.LEFT;

        yield return new WaitForSeconds(RoutineTime);
        StartCoroutine("ChangeMove");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger == false)
        {
            if(other.CompareTag("Player"))
            {
                target = other.gameObject;
            }
            if (other.gameObject == target)
                StopCoroutine("ChangeMove");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.isTrigger == false)
        {
            if (other.gameObject == target)
                trace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.isTrigger == false)
        {
            if (other.gameObject == target)
            {
                trace = false;
                StartCoroutine("ChangeMove");
            }
        }
    }
}
