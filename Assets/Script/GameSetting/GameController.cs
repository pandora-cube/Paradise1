using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioSource Paradise;
    public Image Logo;
    public Text Over;
    IEnumerator StartLogo()
    {
        Paradise.Play();
        yield return new WaitForSeconds(14);
        Logo.gameObject.SetActive(true);
        yield return new WaitForSeconds(26);
        Paradise.volume = 0.1f;
        yield return new WaitForSeconds(2f);
        Paradise.Stop();
        Destroy(Logo);
    }

    public IEnumerator GameOver()
    {
        Over.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    public void StartFirst()
    {
        StartCoroutine("StartLogo");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex +1);
    }

}
