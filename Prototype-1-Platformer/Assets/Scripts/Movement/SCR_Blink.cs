using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Blink : MonoBehaviour
{

    [Header("Editable Values")]
    [Tooltip("How fast the blink happens.")]
    public float blinkDistance;
    private Rigidbody playerRB;
    public SpellManager spellManager;
    public GameObject forwardGlow;

    private void Awake()
    {
        playerRB = this.GetComponent<Rigidbody>();
    }

    public void BlinkDown()
    {
        if(Input.GetKey(KeyCode.W))
        {
            forwardGlow.SetActive(true);
        }
        else
        {
            forwardGlow.SetActive(true);
        }
    }

    public void BlinkReleaseFront()
    {
        forwardGlow.SetActive(false);
        AbilityControl.Ability2Cooldown = true;
        playerRB.AddForce(transform.forward * blinkDistance, ForceMode.Impulse);
    }
}
