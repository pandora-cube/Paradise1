using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject Weapon = null;
    private HacksysFunda hack;
    public Transform Firepoint;
    private float delay;
    private float nextFire;
    private bool ishacked;
    public GameObject GetWeapon()           //소지 무기 반환
    {
        return Weapon;
    }

    public void SetWeapon(GameObject weapon)
    {
        Weapon = weapon;
    }

    private void Start()
    {
        nextFire = Time.time;
        if(TryGetComponent(out HacksysFunda hacksys))
        {
            hack = hacksys;
        }
        
    }
    private void Update()
    {

        if (Weapon != null)
        {
            delay = Weapon.GetComponent<Weapon>().delay;

            if (Input.GetKeyDown(KeyCode.Space)&&(gameObject.CompareTag("Player")||hack.isHacked))
            {
                Shoot();
            }

            else if(gameObject.CompareTag("Monster")&&!hack.isHacked)
            {
                if(gameObject.GetComponent<MonsterAI>().trace)
                {
                    Shoot();
                }
            }

            else if(gameObject.CompareTag("Turret"))
            {
                if (gameObject.GetComponent<TurretAI>().trace)
                {
                    Shoot();
                }
            }            
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            Instantiate(Weapon.GetComponent<Weapon>().bullet, Firepoint.position, Firepoint.rotation);
            nextFire = Time.time + delay;
        }
    }
}
