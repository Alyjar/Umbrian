using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PressurePlateScript : MonoBehaviour
{
    public GameObject doorManager;
    public GameObject player;
    public Transform centreTransform;
    private DoorManager manager;
    private SCR_LevitateMechanic levitationScript;

    private void Start()
    {
        manager = doorManager.GetComponent<DoorManager>();
        levitationScript = player.GetComponent<SCR_LevitateMechanic>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PuzzleSphere"))
        {
            other.attachedRigidbody.isKinematic = true;
            other.transform.position = centreTransform.position;
            levitationScript.currentObject = null;
            levitationScript.hasGrabbed = false;
            manager.weightCount++;
            this.enabled = false;
        }
    }
}
