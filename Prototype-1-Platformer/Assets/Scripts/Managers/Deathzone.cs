using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathzone : MonoBehaviour
{

    public GameObject player;
    public GameObject spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Testing Deathzone");

            if (player.GetComponent<SCR_LevitateMechanic>().hasGrabbed)
            {
                player.GetComponent<SCR_LevitateMechanic>().DropObject();
            }          
            player.transform.position = spawnPoint.transform.position;
        }
    }
}
