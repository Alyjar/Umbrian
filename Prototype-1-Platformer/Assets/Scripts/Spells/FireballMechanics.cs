using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMechanics : MonoBehaviour
{
    public GameObject explosion;
    private Rigidbody fireballRigidbody;
    private MeshRenderer mRenderer;

    private void Start()
    {
        fireballRigidbody = this.GetComponent<Rigidbody>();
        mRenderer = this.GetComponent<MeshRenderer>();
        explosion.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Destroying Projectile");
        mRenderer.enabled = false;
        explosion.SetActive(true);
        fireballRigidbody.isKinematic = true;
        StartCoroutine(ExplosionTimer());
        if (other.CompareTag("destructible"))
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    }
}
