using System.Collections;
using UnityEngine;

namespace Spell_Management.Spells.Base
{
    public class SpellBase : MonoBehaviour
    {
        [Tooltip("Dictates if the player can cast this spell")]
        public bool canCast = true;
        
        public virtual void PerformSpell()
        {
            // Can be overwritten by inheriting classes
        }

        public virtual IEnumerator SpellCooldown(int spellCooldown)
        {
            yield return new WaitForSeconds(spellCooldown);
            canCast = true;
        }
        
    }
}
