using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Background;
    [SerializeField]
    public GameObject player;
    private Camera cam;
    private float cameraScale;
    private Vector3 Mousepoint;       //마우스 좌표
    public RaycastHit2D[] mouseHit;

    void Start()
    {
        cameraScale = Camera.main.orthographicSize / 5;
        cam = GetComponent<Camera>();
    }


    void Update()
    {
        if (player != null)
        {
            BackFollow();
            cameraMove();
        }
        MouseRay();
    }
    private void MouseRay()        //마우스 위치 설정
    {
        Mousepoint = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseHit = Physics2D.RaycastAll(Mousepoint, Vector2.up, 15f);
        Debug.DrawRay(Mousepoint, transform.forward * 15, Color.red, 0.3f);
    }

    void BackFollow()
    {
        if (Background.position != transform.position + new Vector3(0, 2.5f, 10))
        {
            Background.position = transform.position + new Vector3(0, 2.5f, 10);
            Background.localScale = new Vector3((float)(1.12 * cameraScale), (float)(1.1 * cameraScale), 1f * cameraScale);
        }
    }

    void cameraMove()
    {
        if (player.transform.position.x > transform.position.x + 9f)
            transform.position += new Vector3(18f, 0, 0);
        else if(player.transform.position.x < transform.position.x - 9f)
            transform.position -= new Vector3(18f, 0, 0);
    }
}
