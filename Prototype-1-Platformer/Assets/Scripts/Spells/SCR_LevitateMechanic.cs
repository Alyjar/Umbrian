using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_LevitateMechanic : MonoBehaviour
{
    public bool hasGrabbed;
    public float rayDistance;
    public GameObject currentObject;
    public GameObject objectPosition;
    public GameObject objectHitPosition;
    public GameObject cameraPosition;
    public Camera playerCamera;
    private bool objectCentre;
    public bool currentSpell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpell)
        {
            PickupObject();
            MoveObject();
        }
    }

    public void PickupObject()
    {
        if(Input.GetButtonDown("Fire1") && !hasGrabbed)
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayDistance) && hit.rigidbody != null)
            {
                currentObject = hit.collider.gameObject;
                objectHitPosition.transform.position = currentObject.transform.position;
                currentObject.GetComponent<Rigidbody>().isKinematic = false;
                hasGrabbed = true;
            }
        }
        else if (Input.GetButtonDown("Fire2") && hasGrabbed)
        {
            DropObject();
        }
    }

    public void MoveObject()
    {
        if (hasGrabbed)
        {
            currentObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Vector3 moveDirection = (objectHitPosition.transform.position - currentObject.transform.position);
            currentObject.GetComponent<Rigidbody>().AddForce(moveDirection * 150f);

            if(objectCentre == false)
            {
                objectHitPosition.transform.position = Vector3.MoveTowards(objectHitPosition.transform.position, objectPosition.transform.position, 2f * Time.fixedDeltaTime);
            }

            if(objectHitPosition.transform.position == objectPosition.transform.position)
            {
                objectCentre = true;
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            objectHitPosition.transform.Translate(0, 0, scroll * 5, Space.Self);

            if(Vector3.Distance(currentObject.transform.position, objectHitPosition.transform.position) > 40f)
            {
                DropObject();
            }
        }
    }

    public void DropObject()
    {
        currentSpell = false;
        currentObject.GetComponent<Rigidbody>().useGravity = true;
        currentObject.GetComponent<Rigidbody>().drag = 0;
        currentObject = null;
        hasGrabbed = false;
    }
}
