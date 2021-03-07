using UnityEngine;
using UnityEngine.Events;

namespace EventSystem.Scripts.GameEvents
{
    public class Events : MonoBehaviour
    {
        public static Events current;
        public int currentGemValue;

        private void Awake()
        {
            current = this;
        }

        public UnityEvent onCoinPickup;
        public void CoinPickup(int gemValue)
        {
            currentGemValue = gemValue;
            onCoinPickup?.Invoke();
        }
    }
}
