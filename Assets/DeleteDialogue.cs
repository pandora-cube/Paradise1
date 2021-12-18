using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDialogue : MonoBehaviour
{
    void Update()
    {
        if(gameObject.GetComponent<StartDialogueByCollider>().finish)
        {
            Destroy(gameObject);
        }
    }
}
