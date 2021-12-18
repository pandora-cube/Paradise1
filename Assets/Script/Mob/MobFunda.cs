using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobFunda : MonoBehaviour
{
    [SerializeField]
    private int Hp = 100;           //체력
    private GameObject player;
    public float Speed;

    private void Start()
    {
        if (TryGetComponent(out Rigidbody2D rigid))
        {
            rigid.freezeRotation = true;
        }

        player = Camera.main.GetComponent<CameraMove>().player;
    }
    public int GetHp()                      //체력 값 반환
    {
        return Hp;
    }

    public void Gethit(int damage)
    {
        Hp -= damage;

        if(Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(gameObject == player)
        {
            FindObjectOfType<GameController>().StartCoroutine("GameOver");
        }
        
        else if(TryGetComponent(out HacksysFunda hacksys))
        {
            if(hacksys.isHacked)
            {
                if(hacksys.slotPanel.TryGetComponent(out RobotPanel robo))
                {
                    robo.QuitPanel();
                }
                else if(hacksys.slotPanel.TryGetComponent(out DoorPanel door))
                {
                    door.QuitPanel();
                }
                else if(hacksys.slotPanel.TryGetComponent(out TurretPanel turret))
                {
                    turret.QuitPanel();
                }
            }
        }
        Destroy(gameObject);
    }
}