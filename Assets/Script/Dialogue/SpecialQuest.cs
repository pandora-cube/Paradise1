using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialQuest : MonoBehaviour
{
    public Text timer;
    public Text hp;
    public MobFunda Compiler;
    public MonsterSpawner[] spawners = new MonsterSpawner[3];
    public GameObject Toma;
    private bool isOn = false;
    private float time = 90;
    public void StartQuest()
    {
        Debug.Log("Start Special Quest!!");
        Compiler.gameObject.tag = "Player";
        gameObject.GetComponent<AudioSource>().Play();
        timer.gameObject.SetActive(true);
        hp.gameObject.SetActive(true);
        isOn = true;
        StartCoroutine(TimeSet());
        foreach(MonsterSpawner i in spawners)
        {
            i.StartSpawn();
        }
    }

    void FinishQuest()
    {
        gameObject.GetComponent<AudioSource>().Stop();
        Compiler.tag = "Wall";
        timer.gameObject.SetActive(false);
        hp.gameObject.SetActive(false);
        isOn = false;
        Toma.SetActive(true);
        foreach (MonsterSpawner i in spawners)
        {
            i.StopSpawn();
        }
    }

    IEnumerator TimeSet()
    {
        yield return new WaitForSeconds(1);
        time -= 1;
        if(time<=0)
        {
            FinishQuest();
        }
        else
        {
            StartCoroutine(TimeSet());
        }
    }

    private void Update()
    {
        if(isOn)
        {
            timer.text = time.ToString() + "초 남음";
            hp.text = "중계기 내구도: " + Compiler.GetHp().ToString();
        }
    }
}
