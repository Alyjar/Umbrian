using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityControl : MonoBehaviour
{
    public int ActiveAbility = 1;

    public SpellManager spellManager;

    //cooldowns
    private float cooldown1 = 3;
    private float cooldown2 = 4;
    private float cooldown3 = 3;
    private float cooldown4 = 3;
    private float cooldown5 = 3;

    //Icons
    public Image Ability1CooldownIcon;
    public Image Ability2CooldownIcon;
    public Image Ability3CooldownIcon;
    public Image Ability4CooldownIcon;
    public Image Ability5CooldownIcon;

    //cooldown bools
    bool Ability1Cooldown;
    public static bool Ability2Cooldown;
    bool Ability3Cooldown;
    bool Ability4Cooldown;
    bool Ability5Cooldown;

    //Icon Positions
    Vector2 MainIcon;
    Vector2 Icon1;
    Vector2 Icon2;
    Vector2 Icon3;
    Vector2 Icon4;
    Vector2 Icon5;

    //Game objects
    public GameObject MainIconAnchor;
    public GameObject Icon1Anchor;
    public GameObject Icon2Anchor;
    public GameObject Icon3Anchor;
    public GameObject Icon4Anchor;
    public GameObject Icon5Anchor;

    Vector2 largeIconScale = new Vector2(1.1f, 1.1f);
    Vector2 smallIconScale = new Vector2(0.68f, 0.68f);



    // Start is called before the first frame update
    void Start()
    {
        MainIcon = MainIconAnchor.transform.position;
        Icon1 = Icon1Anchor.transform.position;
        Icon2 = Icon2Anchor.transform.position;
        Icon3 = Icon3Anchor.transform.position;
        Icon4 = Icon4Anchor.transform.position;
        Icon5 = Icon5Anchor.transform.position;

        Icon1Anchor.transform.position = MainIcon;
        Icon1Anchor.transform.localScale = largeIconScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Setting Active Abilities

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveAbility = 1;

            IconTransforms(Icon1Anchor, MainIcon, largeIconScale);
            IconTransforms(Icon2Anchor, Icon2, smallIconScale);
            IconTransforms(Icon3Anchor, Icon3, smallIconScale);
            IconTransforms(Icon4Anchor, Icon4, smallIconScale);
            IconTransforms(Icon5Anchor, Icon5, smallIconScale);
  
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveAbility = 2;

            IconTransforms(Icon1Anchor, Icon1, smallIconScale);
            IconTransforms(Icon2Anchor, MainIcon, largeIconScale);
            IconTransforms(Icon3Anchor, Icon3, smallIconScale);
            IconTransforms(Icon4Anchor, Icon4, smallIconScale);
            IconTransforms(Icon5Anchor, Icon5, smallIconScale);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveAbility = 3;

            IconTransforms(Icon1Anchor, Icon1, smallIconScale);
            IconTransforms(Icon2Anchor, Icon2, smallIconScale);
            IconTransforms(Icon3Anchor, MainIcon, largeIconScale);
            IconTransforms(Icon4Anchor, Icon4, smallIconScale);
            IconTransforms(Icon5Anchor, Icon5, smallIconScale);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiveAbility = 4;

            IconTransforms(Icon1Anchor, Icon1, smallIconScale);
            IconTransforms(Icon2Anchor, Icon2, smallIconScale);
            IconTransforms(Icon3Anchor, Icon3, smallIconScale);
            IconTransforms(Icon4Anchor, MainIcon, largeIconScale);
            IconTransforms(Icon5Anchor, Icon5, smallIconScale);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ActiveAbility = 5;

            IconTransforms(Icon1Anchor, Icon1, smallIconScale);
            IconTransforms(Icon2Anchor, Icon2, smallIconScale);
            IconTransforms(Icon3Anchor, Icon3, smallIconScale);
            IconTransforms(Icon4Anchor, Icon4, smallIconScale);
            IconTransforms(Icon5Anchor, MainIcon, largeIconScale);
        }

        //Ability usage

        if(Input.GetMouseButtonDown(0))
        {
            if (ActiveAbility == 1)
            {
                Ability1();
            }

            else if (ActiveAbility == 2)
            { 
                Ability2(); 
            }

            else if (ActiveAbility == 3)
            {
                Ability3();
            }

            else if (ActiveAbility == 4)
            {
                Ability4(); 
            }

            else if (ActiveAbility == 5)
            { 
                Ability5();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(ActiveAbility == 2)
            {
                spellManager.blinkScript.BlinkReleaseFront();
            }
            /*
            if (ActiveAbility == 2 && Input.GetKeyDown(KeyCode.W))
            {
                spellManager.blinkScript.BlinkReleaseFront();
            }
            if (ActiveAbility == 2 && Input.GetKeyDown(KeyCode.S))
            {
                spellManager.blinkScript.BlinkReleaseBack();
            }
            if (ActiveAbility == 2 && Input.GetKeyDown(KeyCode.A))
            {
                spellManager.blinkScript.BlinkReleaseLeft();
            }
            if (ActiveAbility == 2 && Input.GetKeyDown(KeyCode.D))
            {
                spellManager.blinkScript.BlinkReleaseRight();
            }
            */
        }

        //Ability cooldowns

        //Ability 1 cooldown
        if (Ability1Cooldown)
        {
            Ability1CooldownIcon.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (Ability1CooldownIcon.fillAmount <= 0)
            {
                Ability1CooldownIcon.fillAmount = 0;
                Ability1Cooldown = false;
            }
        }

        //Ability 2 cooldown
        if (Ability2Cooldown)
        {
            Ability2CooldownIcon.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (Ability2CooldownIcon.fillAmount <= 0)
            {
                Ability2CooldownIcon.fillAmount = 0;
                Ability2Cooldown = false;
            }
        }

        //Ability 3 cooldown
        if (Ability3Cooldown)
        {
            Ability3CooldownIcon.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (Ability3CooldownIcon.fillAmount <= 0)
            {
                Ability3CooldownIcon.fillAmount = 0;
                Ability3Cooldown = false;
            }
        }

        //Ability 4 cooldown
        if (Ability4Cooldown)
        {
            Ability4CooldownIcon.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (Ability4CooldownIcon.fillAmount <= 0)
            {
                Ability4CooldownIcon.fillAmount = 0;
                Ability4Cooldown = false;
            }
        }

        //Ability 5 cooldown
        if (Ability5Cooldown)
        {
            Ability5CooldownIcon.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (Ability5CooldownIcon.fillAmount <= 0)
            {
                Ability5CooldownIcon.fillAmount = 0;
                Ability5Cooldown = false;
            }
        }
    }

    public void IconTransforms(GameObject iconAnchor, Vector2 icon, Vector2 scale)
    {
        iconAnchor.transform.position = icon;
        iconAnchor.transform.localScale = scale;
    }

    public void Ability1()
    {
        if (Ability1Cooldown == false)
        {
            Ability1Cooldown = true;
            Ability1CooldownIcon.fillAmount = 1;
            spellManager.Fireball();
        }
    }

    public void Ability2()
    {
        if (!Ability2Cooldown)
        {
            Ability2Cooldown = true;
            Ability2CooldownIcon.fillAmount = 1;
            spellManager.blinkScript.BlinkDown();
        }
    }

    public void Ability3()
    {
        if (Ability3Cooldown == false)
        {
            Ability3Cooldown = true;
            Ability3CooldownIcon.fillAmount = 1;
            spellManager.levitationScript.currentSpell = true;
        }
    }

    public void Ability4()
    {
        if (Ability4Cooldown == false)
        {
            Ability4Cooldown = true;
            Ability4CooldownIcon.fillAmount = 1;
        }
    }

    public void Ability5()
    {
        if (Ability5Cooldown == false)
        {
            Ability5Cooldown = true;
            Ability5CooldownIcon.fillAmount = 1;
        }
    }
}
