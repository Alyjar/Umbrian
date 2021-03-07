using Spell_Management.Spells.Base;
using Spell_Management.Spells.Children;
using UnityEngine;

namespace Spell_Management.Manager
{
    public class SpellManager : MonoBehaviour
    {

        [Header("Spell Binds")]
        public KeyCode fireballBind = KeyCode.Alpha1;
        public KeyCode levitationBind = KeyCode.Alpha2;
        public KeyCode blinkBind = KeyCode.Alpha3;

        [Header("Spell Variables")] 
        public SpellBase currentSpell;

        private void Start()
        {
            currentSpell = GetComponent<Fireball>();
        }

        private void PerformSpell()
        {
            currentSpell.PerformSpell();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(fireballBind))
            {
                currentSpell = gameObject.GetComponent<Fireball>();
            }
            else if (Input.GetKeyDown(levitationBind))
            { 
                currentSpell = gameObject.GetComponent<Levitation>();
            }
            else if (Input.GetKeyDown(blinkBind))
            {
                currentSpell = gameObject.GetComponent<Blink>();
            }

            if (Input.GetMouseButtonDown(0) && currentSpell.canCast)
            {
                PerformSpell();
            }
        }
    }
}
