using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour         //점프 가능여부(땅에 닿아 있는지)
{
    [SerializeField]
    private float Jspeed;                    //점프 속도
    private bool isGround = false;        //지면 접촉 여부
    private float Input_y;

    private void FixedUpdate()
    {
        Jump();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
    
    private void Jump()
    {
        Input_y = Input.GetAxisRaw("Vertical");
        if ((Input_y == 1) && isGround)
            gameObject.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0, Jspeed), ForceMode2D.Impulse);
    }
}