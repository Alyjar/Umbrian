using EventSystem.Scripts.GameEvents;
using UnityEngine;
using UnityEngine.UI;

namespace EventSystem.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Coin Collection Variables")] 
        private int currentCoinsCollected = 0;

        [Header("UI References")] [SerializeField]
        private Text scoreText;

        public void Current_onCoinPickup()
        {
            currentCoinsCollected += Events.current.currentGemValue;
            scoreText.text = "Gems: " + currentCoinsCollected.ToString();
            Debug.Log(currentCoinsCollected);
        }
    }
}
