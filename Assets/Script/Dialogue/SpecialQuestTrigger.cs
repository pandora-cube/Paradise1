using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialQuestTrigger : MonoBehaviour
{
    public GameObject Player;
    public SpecialQuest Quest;
    public GameObject Gun;
    private GunShoot shoot;

    private void Start()
    {
        shoot = Player.GetComponent<GunShoot>();
    }

    private void FixedUpdate()
    {
        if(gameObject.GetComponent<StartDialogueByCollider>().finish)
        {
            TriggerQuest();
        }
    }
    private void TriggerQuest()
    {
        Destroy(shoot.GetWeapon());
        shoot.SetWeapon(Gun);
        Quest.StartQuest();
        gameObject.SetActive(false);
    }
}
