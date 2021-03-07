using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float health = 100;
    public Image healthFill;
    public Transform spawnPoint;
    private CharacterController charController;

    private void Start()
    {
        health = maxHealth;
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {

        healthFill.fillAmount = health / 100;

        if (health <= 0)
        {
            charController.enabled = false;
            transform.position = spawnPoint.transform.position;
            charController.enabled = true;
            health = 100;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
    }

    public void HealDamage(float healAmount)
    {
        health += healAmount;
    }
}
