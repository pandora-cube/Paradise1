﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(Camera.main.ScreenToWorldPoint(Input.mousePosition),new Quaternion(0,0,0,0));
    }
}
