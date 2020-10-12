using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject Player;
    private bool triggerEntered = false;
    private bool alreadyEntered = false;

    private void Update()
    {
        HidePlayer();
    }

    private void HidePlayer()
    {
        if (Input.GetKeyDown(KeyCode.A) && alreadyEntered == true)
        {
            Player.SetActive(true);
            alreadyEntered = false;
        }
        else if(Input.GetKeyDown(KeyCode.A) && triggerEntered == true && alreadyEntered == false)
        {
            alreadyEntered = true;
            Player.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEntered = true;
    }

    private void OnTriggerExit()
    {
        triggerEntered = false;
    }
}
