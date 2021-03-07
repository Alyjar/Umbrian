using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{
    [Header("References.")]
    public GameObject player;
    [Header("Public Variables.")]
    [Tooltip("References the fireball prefab.")]
    public GameObject fireball;
    [Tooltip("References the firing position of the spell.")]
    public Transform firingPosition;
    [Tooltip("The speed at which the fireball travels.")]
    public int fireballFiringSpeed = 10;
    [Tooltip("How long before the fireball is removed from the scene.")]
    public int fireballRemovalTimer = 3;
    [Tooltip("How long the player has to wait between fireballs.")]
    public int fireballCooldown = 3;
    public int blinkCooldown = 4;
    public int levitateCooldown = 3;
    public Image FireballUI;

    [Header("Private Variables.")]
    public bool canFireFireball = true;
    //public bool canBlink = true;

    /*private*/public SCR_Blink blinkScript; //commented out private tag + added public tag to allow my script to access it - Billy
    public SCR_LevitateMechanic levitationScript;

    void Start()
    {
        levitationScript = player.GetComponent<SCR_LevitateMechanic>();
        blinkScript = player.GetComponent<SCR_Blink>();
    }


    // Update is called once per frame
    void Update()
    {
        SpellDefine();
    }

    /** 
     * Function: Spell Define.
     * Description: Switches between what spell the player has selected. 
     * Completion: Currently using a pretty bad method, going to see if I can improve.
     * Contact: Dave. 
     */

    void SpellDefine() // commented out redundant areas that were causing issues with my script - Billy
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1) && canFireFireball)
        //{
        //    Fireball();
        //}
        
        //else if (Input.GetKeyDown(KeyCode.Alpha2) && canBlink)
        //{
        //    blinkScript.Blink();
        //}

        /*else*/ if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //levitationScript.PickupObject();
            //levitationScript.MoveObject();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {

        }
    }

    /** 
     * Function: Fireball.
     * Description: Launches a fireball towards where the player is looking and sets the parent to the spawner. 
     * Completion: Done until animations and damage implemented.
     * Contact: Dave. 
     */

    public void Fireball() //added the public tag to allow my script to access it - Billy
    {
        GameObject fired = GameObject.Instantiate(fireball, firingPosition);
        fired.GetComponent<Rigidbody>().AddForce(firingPosition.transform.forward * fireballFiringSpeed);
        fired.transform.SetParent(this.transform);
        Destroy(fired.gameObject, fireballRemovalTimer);
        
        canFireFireball = false;

        StartCoroutine(FireballCooldown(fireballCooldown));
    }

    /**
     * Function: Fireball Cooldown.
     * Description: Waits for a certain amount of time which can be set within the inspector then allows the program to fire again.
     * Completion: Finished.
     * Contact: Dave.
     */

    IEnumerator FireballCooldown(int cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canFireFireball = true;
    }
    public IEnumerator BlinkCooldown(int cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        //canBlink = true;
    }
}
