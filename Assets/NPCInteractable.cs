using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public dialouguemanager dialouguemanager;
    public KeyCode interactKey = KeyCode.E;

    bool player_detection = false;
   


    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            dialouguemanager.Start();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "player")
        {
            player_detection = true;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "player")
        {
            player_detection = false;
        }
    }
}
