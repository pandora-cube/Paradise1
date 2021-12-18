using System.Collections;
using UnityEngine;

public class PlayerHack : MonoBehaviour
{
    [SerializeField]
    private GameObject Device = null;   //해킹용 디바이스
    private MobFunda mob;
    public bool HackOn;
    [System.NonSerialized]
    public CameraMove CamSet;
    private ConsoleController console;

    private void Start()
    {
        CamSet = Camera.main.GetComponent<CameraMove>();
        mob = GetComponent<MobFunda>();
        HackOn = false;
        console = FindObjectOfType<ConsoleController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("OnClick");
            foreach(RaycastHit2D i in CamSet.mouseHit)
            {
                if (i && !HackOn)
                {
                    Debug.Log("1");
                    Debug.Log(i.collider.gameObject.name);
                    GameObject hitted = i.collider.gameObject;
                    if (hitted.TryGetComponent(out HacksysFunda Hiton) && (hitted != gameObject))
                    {
                        Debug.Log("2");
                        if (!Hiton.isHacked && (Hiton.getCache() <= Device.GetComponent<Devices>().RestRam()))
                        {
                            Debug.Log("3");
                            StartCoroutine(OnHack(Hiton));
                        }
                    }
                }
            }
        }
    }
    public GameObject GetDevice()           //소지 디바이스 반환
    {
        return Device;
    }

    public void SetDevice(GameObject device)
    {
        Device = device;
    }

    public IEnumerator OnHack(HacksysFunda target)
    {
        Debug.Log("Coroutine");
        HackOn = true;
        if (console.OnDial) console.EndDialogue(0);
        if (target.getCache() > Device.GetComponent<Devices>().RestRam())
        {
            Debug.Log("Ram null");
            console.dialogueText.text = "램 부족";
            HackOn = false;
            yield break;
        }

        float i;
        int hp = mob.GetHp();

        console.dialogueText.text = (target.name + "해킹 노드 실행중...");
        for (i = 0; i < 4f; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            if (mob.GetHp() < hp)
            {
                console.dialogueText.text = "외부 충격에 의해 노드 취소됨";
                HackOn = false;
                yield break;
            }
        }

        console.dialogueText.text = target.name + "해킹 성공";
        target.HackOn(Device.GetComponent<Devices>());
        HackOn = false;
    }

}
