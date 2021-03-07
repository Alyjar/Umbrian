using Spell_Management.Spells.Base;
using UnityEngine;

namespace Spell_Management.Spells.Children
{
    public class Fireball : SpellBase
    {
        [Header("References")]
        [Tooltip("Prefab that stores the fireball object")]
        public GameObject fireballPrefab;
        [Tooltip("Firing position of the fireball (is attached to the camera)")]
        public Transform firingPosition;

        [Header("Fireball Settings")]
        [Tooltip("How long it takes to remove the fireball if it doesn't hit anything")]
        public float fireballRemovalTimer;
        [Tooltip("How long before you can cast the fireball again")]
        public int fireballSpellCooldown = 3;

        public Fireball()
        {
            canCast = true;
        }


        /// <summary>
        /// Performs the fireball spell.
        /// It spawns the object under the reference of spawnedFireball from the firing position.
        /// It destroys the fireball after a certain amount of time and sets the ability to cast
        /// to false.
        /// </summary>
        public override void PerformSpell()
        {
            GameObject spawnedFireball = Instantiate(fireballPrefab, firingPosition);
            spawnedFireball.transform.SetParent(this.transform);
            
            Destroy(spawnedFireball.gameObject, fireballRemovalTimer);
            canCast = false;

            StartCoroutine(SpellCooldown(fireballSpellCooldown));
        }
    }
}
