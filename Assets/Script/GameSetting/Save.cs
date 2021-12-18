using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save  : MonoBehaviour
{
    private int chapter = 0;
    public GameObject player;
    [SerializeField]
    private Devices device;

    private void Update()
    {
        chapterCount();
        if(player.GetComponent<PlayerHack>().GetDevice() != null)
        {
            device = player.GetComponent<PlayerHack>().GetDevice().GetComponent<Devices>();
        }
    }
    public void SaveChapter()
    {
        PlayerPrefs.SetInt("Chapter", chapter);
        if (device != null)
        {
            PlayerPrefs.SetInt("Ramcount", device.RamCount);
            PlayerPrefs.SetFloat("Ram",device.Ram);
        }
    }

    private void chapterCount()
    {
        if ((player.transform.position.x >= 28) && (player.transform.position.x < 92))
        {
            chapter = 1;
            SaveChapter();
        }
        else if (player.transform.position.x >= 92)
        {
            chapter = 2;
            SaveChapter();
        }
        else
            return;
    }
}
