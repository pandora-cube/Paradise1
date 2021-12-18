using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPanel : MonoBehaviour
{
    public GameObject turret;
    private MobFunda turSet;
    private HacksysFunda hacksys;
    private GunShoot shoot;

    public Image image;
    public Slider hp;
    public Toggle trace;

    private void Start()
    {
        turSet = turret.GetComponent<MobFunda>();
        hacksys = turret.GetComponent<HacksysFunda>();
        shoot = turret.GetComponent<GunShoot>();
        image.sprite = turret.GetComponent<SpriteRenderer>().sprite;

        Weapon weapon = shoot.GetWeapon().GetComponent<Weapon>();
        if (weapon.bullet.CompareTag("Missile"))
        {
            weapon.bullet = Resources.Load("Bullet/CustomMissile") as GameObject;
        }
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        hp.value = turSet.GetHp();
        if(trace.isOn)
        {
            player.GetComponent<MoveController>().enabled = false;
            player.GetComponent<PlayerHack>().enabled = false;
            player.GetComponent<GunShoot>().enabled = false;
            player.GetComponentInChildren<PlayerJump>().enabled = false;

            shoot.enabled = true;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;

            Vector2 range = gameObject.transform.InverseTransformPoint(mousePos);
            float angle = Mathf.Atan2(range.x, range.y) * Mathf.Rad2Deg;

            turret.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, +gameObject.transform.rotation.eulerAngles.z + angle - 180);
        }

        else if(!trace.isOn)
        {
            player.GetComponent<MoveController>().enabled = true;
            player.GetComponent<PlayerHack>().enabled = true;
            player.GetComponent<GunShoot>().enabled = true;
            player.GetComponentInChildren<PlayerJump>().enabled = true;
            shoot.enabled = false;  
        }

        if (Input.GetKeyDown(KeyCode.F) && !trace.isOn)
        {
            QuitPanel();
        }
    }

    public void QuitPanel()
    {
        turret.GetComponent<GunShoot>().enabled = true;
        turret.GetComponent<TurretAI>().enabled = true;
        turret.GetComponent<TurretAI>().target = GameObject.FindGameObjectWithTag("Player");
        hacksys.HackOff();

        SlotController slotController = GetComponentInParent<SlotController>();
        slotController.slotPanel.Remove(slotController.panelnode);
        slotController.panelnode = slotController.slotPanel.First;

        Weapon weapon = shoot.GetWeapon().GetComponent<Weapon>();
        if (weapon.bullet.CompareTag("Missile"))
        {
            weapon.bullet = Resources.Load("Bullet/Missile") as GameObject;
        }
        Destroy(gameObject);
    }
}