using Spell_Management.Spells.Base;
using UnityEngine;

namespace Spell_Management.Spells.Children
{
    public class Levitation : SpellBase
    {

        public int levitationCooldown = 3;
        
        /// <summary>
        /// 
        /// </summary>
        public override void PerformSpell()
        {
            Debug.Log("Levitation Called");
            canCast = false;

            StartCoroutine(SpellCooldown(levitationCooldown));
        }
    }
}
