using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compiler : MonoBehaviour
{
    public MonoBehaviour funda;
    private void OnDestroy()
    {
        funda.enabled = true;
    }
}
