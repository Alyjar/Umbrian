using EventSystem.Scripts.GameEvents;
using UnityEngine;

namespace EventSystem.Scripts.EventTriggers
{
    public class TriggerCoinCollection : MonoBehaviour
    {

        [Header("Gem Variables")]
        public int gemValueSmall = 10;
        public int gemValueLarge = 50;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("GemSmall"))
            {
                Debug.Log("Triggered");
                Events.current.CoinPickup(gemValueSmall);
                Destroy(other.gameObject);  
            }
            
            if (!other.CompareTag("GemLarge")) return;
            
            Debug.Log("Triggered");
            Events.current.CoinPickup(gemValueLarge);
            Destroy(other.gameObject);
        }
    }
}
