using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotPanel : MonoBehaviour
{
    public GameObject robo = null;
    private MobFunda roboSet = null;
    private HacksysFunda hacksys = null;
    private MoveController controller = null;
    private GunShoot[] shoot = null;

    public Image image;
    public Slider hp;
    public Toggle toggle;

    private void Start()
    {
        roboSet = robo.GetComponent<MobFunda>();
        hacksys = robo.GetComponent<HacksysFunda>();
        controller = robo.GetComponent<MoveController>();
        shoot = robo.GetComponents<GunShoot>();
        image.sprite = robo.GetComponent<SpriteRenderer>().sprite;

        foreach(GunShoot i in shoot)
        {
            Weapon weapon = i.GetWeapon().GetComponent<Weapon>();
            if (weapon.bullet.CompareTag("Missile"))
            {
                weapon.bullet = Resources.Load("Bullet/CustomMissile") as GameObject;
            }
            else if(weapon.bullet.CompareTag("Bullet"))
            {
                weapon.bullet = Resources.Load("Bullet/CustomBullet") as GameObject;
            }
        }
    }
    private void Update()
    {        
        hp.value = roboSet.GetHp();

        if (Input.GetKeyDown(KeyCode.F) && !toggle.isOn)
        {
            QuitPanel();
        }
    }
    public void Controllerset()
    {
        if(toggle.isOn)
        {
            robo.tag = "Player";
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<MoveController>().enabled = false;
            player.GetComponent<PlayerHack>().enabled = false;
            player.GetComponent<GunShoot>().enabled = false;
            player.GetComponentInChildren<PlayerJump>().enabled = false;

            controller.enabled = true;
            foreach (GunShoot i in shoot)
            {
                i.enabled = true;
            }
        }

        else if (!toggle.isOn)
        {
            robo.tag = "Monster";
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<MoveController>().enabled = true;
            player.GetComponent<PlayerHack>().enabled = true;
            player.GetComponent<GunShoot>().enabled = true;
            player.GetComponentInChildren<PlayerJump>().enabled = true;

            controller.enabled = false;
            foreach(GunShoot i in shoot)
            {
                i.enabled = false;
            }
        }
    }

    public void QuitPanel()
    {
        hacksys.HackOff();
        SlotController slotController = GetComponentInParent<SlotController>();
        slotController.slotPanel.Remove(slotController.panelnode);
        slotController.panelnode = slotController.slotPanel.First;
        robo.GetComponent<MonsterAI>().enabled = true;

        foreach (GunShoot i in shoot)
        {
            Weapon weapon = i.GetWeapon().GetComponent<Weapon>();
            if (weapon.bullet.CompareTag("Missile"))
            {
                weapon.bullet = Resources.Load("Bullet/Missile") as GameObject;
            }
            else if (weapon.bullet.CompareTag("Bullet"))
            {
                weapon.bullet = Resources.Load("Bullet/Bullet") as GameObject;
            }
        }

        Destroy(gameObject);
    }
}