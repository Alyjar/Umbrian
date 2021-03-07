using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastFwd : MonoBehaviour
{
    public Text promptTxt;
    public RaycastHit hit;
    public AbilityControl abilityControl;

    UnityEngine.RaycastHit FixedUpdate()
    {

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10))
        {
            if (hit.collider.gameObject.tag == "TileButton")
            {
                promptTxt.text = "E) Push button";
            }
            else if (hit.collider.gameObject.tag == "Tile")
            {
                promptTxt.text = "E) Rotate tile";
                
            }
            else if (hit.collider.gameObject.tag == "PuzzleSphere")
            {
                if (abilityControl.ActiveAbility == 3)
                {
                    promptTxt.text = "LMB) Levitate";
                }
            }
            else
            {
                promptTxt.text = "";
            }
        }
        else
        {
            promptTxt.text = "";
        }

        return hit;
    }
}