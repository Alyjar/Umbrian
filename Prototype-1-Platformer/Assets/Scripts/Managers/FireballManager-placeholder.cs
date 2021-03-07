using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float speed;
    public Image fireball_UI;
    public SpellManager spellManager;
    public GameObject spawner;

    private float fireballCurrentValue = 100;

    void Start()
    {
        spellManager = spawner.GetComponent<SpellManager>();
    }

    void Update()
    {
        if(spellManager.canFireFireball)
        {
            fireballCurrentValue = 100;
        }
        if (!spellManager.canFireFireball)
        {
            fireballCurrentValue -= speed * Time.deltaTime;
        }


        fireball_UI.fillAmount = fireballCurrentValue / 100;
    }
}
