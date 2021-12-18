using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGameUI : MonoBehaviour
{
    [SerializeField]
    private Slider Hp;               //체력바
    [SerializeField]
    private Slider Ram;              //디바이스 램 사용량
    [SerializeField]
    private Image device;           //디바이스 아이콘
    [SerializeField]
    private Image weapon;            //무기 아이콘
    [SerializeField]
    private Text RamCount;

    public PlayerHack player;       //플레이어
    private GameObject Hackitem;    //소지 디바이스 오브젝트
    private GameObject Shootitem;      //소지 무기 오브젝트

    private void Start()
    {
        Hp.maxValue = player.GetComponent<MobFunda>().GetHp();
    }

    private void Update()
    {
        if (player != null)
        {
            Hp.value = player.GetComponent<MobFunda>().GetHp();       //체력 표시

            if (player.GetDevice() != null)
            {
                Hackitem = player.GetDevice();   //디바이스 이미지
                device.sprite = Hackitem.GetComponent<SpriteRenderer>().sprite;

                Ram.maxValue = Hackitem.GetComponent<Devices>().Ram;
                Ram.value = Hackitem.GetComponent<Devices>().RestRam();

                if(player.GetDevice().GetComponent<Devices>().RamCount != 0)
                {
                    RamCount.text = "+" + player.GetDevice().GetComponent<Devices>().RamCount;
                }
            }

            if (player.GetComponent<GunShoot>().GetWeapon() != null)
            {
                Shootitem = player.GetComponent<GunShoot>().GetWeapon();      //무기 이미지
                weapon.sprite = Shootitem.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }
}
