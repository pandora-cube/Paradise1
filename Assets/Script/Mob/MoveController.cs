using UnityEngine;

public class MoveController : Base
{
    public AudioSource walk;

    private float Input_x;       //x Axis값
    private float Speed;                     //속도
    protected Rigidbody2D rb;        //오브젝트 자체의 리지드

    private void Start()
    {
        if (walk != null)
        {
            walk.Play();
        }

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        Speed = gameObject.GetComponent<MobFunda>().Speed;
    }

    private void FixedUpdate()
    {
        Movement();
        if (Input_x == 0)
        {
            if (walk != null)
            {
                walk.Pause();
            }
        }
    }

    protected void Movement()               //기본 조작
    {
        Input_x = Input.GetAxisRaw("Horizontal");
        if (Input_x < 0)
        {
            if (walk != null)
            {
                walk.UnPause();
            }

            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(-Input_x * Speed, 0, 0);
        }
        else if (Input_x > 0)
        {
            if (walk != null)
            {
                walk.UnPause();
            }

            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Input_x * Speed, 0, 0);
        }
    }
}
