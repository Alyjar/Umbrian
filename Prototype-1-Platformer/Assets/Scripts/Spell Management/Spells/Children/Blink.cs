using Spell_Management.Spells.Base;
using UnityEngine;

namespace Spell_Management.Spells.Children
{
    public class Blink : SpellBase
    {

        public int blinkCooldown = 3;
        
        /// <summary>
        /// 
        /// </summary>
        public override void PerformSpell()
        {
            Debug.Log("Blink Called");
            canCast = false;

            StartCoroutine(SpellCooldown(blinkCooldown));
        }
    }
}
