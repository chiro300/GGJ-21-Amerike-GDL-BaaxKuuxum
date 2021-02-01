using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class DamageOnTouch : MonoBehaviour
    {
        public int damage;        
        public bool knockDownTarget;

        public LayerMask targetLayerMask;

        [ReadOnly]
        public GameObject owner;

        protected BoxCollider2D boxCollider2D;

        private void Awake()
        {
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            Hit(collision);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Hit(collision);
        }

        public void Attack()
        {
            boxCollider2D.enabled = true;
        }

        public void EndAttack()
        {
            boxCollider2D.enabled = false;
        }

        private void Hit(Collider2D collision)
        {
            if (!LayerHelper.LayerInLayerMask(collision.gameObject.layer, targetLayerMask))
                return;

            Health health = collision.gameObject.GetComponent<Health>();

            if (health == null)
                return;

            if (health.health > 0)
            {
                health.AddDamage(damage);
            }    
        }
    }
}
