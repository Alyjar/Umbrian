using UnityEngine;

namespace Spell_Management.Spells.Mechanics
{
    public class FireballMechanics : MonoBehaviour
    {
        private Rigidbody _fireballRigidbody;
        private MeshRenderer _mRenderer;
        public float fireballFiringSpeed = 100f;

        private void Start()
        {
            _fireballRigidbody = this.GetComponent<Rigidbody>();
            _mRenderer = this.GetComponent<MeshRenderer>();
            _fireballRigidbody.AddForce(transform.forward * fireballFiringSpeed, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Destroying Projectile");
            _mRenderer.enabled = false;
            _fireballRigidbody.isKinematic = true;
            
            if (other.CompareTag("destructible"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
