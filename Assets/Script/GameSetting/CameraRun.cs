using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRun : MonoBehaviour
{
    public Transform Background;
    [SerializeField]
    private GameObject player;
    private float cameraScale;
    private Camera Camera;
    public GameObject back1;
    public GameObject back2;
    public float speed;

    private void Start()
    {
        cameraScale = Camera.main.orthographicSize / 5;
        Camera = GetComponent<Camera>();
        StartCoroutine(BackGroundLoop(back1));
        StartCoroutine(BackGroundLoop(back2));
    }

    private void Update()
    {
        if(player != null)
        {
            //BackFollow();
            cameraMove();
        }
    }
    IEnumerator BackGroundLoop(GameObject back)
    {
        
        back.transform.Translate(new Vector3(-0.05f, 0f, 0f));
        yield return new WaitForSeconds(speed/100);
        StartCoroutine(BackGroundLoop(back));
    }
    void BackFollow()
    {
        if (Background.position != transform.position + new Vector3(0, -0.7f, 10))
        {
            Background.position = transform.position + new Vector3(0, -0.7f, 10);
        }
    }

    void cameraMove()
    {
        if (player.transform.position.x > transform.position.x + 5f)
            transform.position += new Vector3(10f, 0, 0);
        else if (player.transform.position.x < transform.position.x - 5f)
            transform.position -= new Vector3(10f, 0, 0);
    }
}
