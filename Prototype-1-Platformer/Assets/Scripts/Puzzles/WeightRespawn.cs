using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRespawn : MonoBehaviour
{

    public Transform spawnPoint;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint = transform;
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");

        if (other.gameObject.tag == "DeathZone")
        {
            Debug.Log("CollidedDZ");
            rb.Sleep();
            rb.position = spawnPoint.position;
            rb.WakeUp();

            //transform.position = spawnPoint.position;
        }
    }
}
