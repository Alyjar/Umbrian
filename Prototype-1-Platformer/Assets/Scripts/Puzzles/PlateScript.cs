using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public GameObject doorManager;
    private DoorManager manager;

    private void Start()
    {
        manager = doorManager.GetComponent<DoorManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "EndPlate")
        {
            manager.puzzleOneComplete = true;
        }
        else if (other.gameObject.tag == "Player" && gameObject.tag == "Trap")
        {
            UnityEngine.Debug.Log("Trap activated, RIP.");
            transform.parent.GetComponent<Animator>().enabled = true;
        }
    }
}
