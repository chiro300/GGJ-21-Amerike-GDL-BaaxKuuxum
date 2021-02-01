using Assets.Scripts.Behaivors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Bullet : MonoBehaviour
    {
        public LayerMask targets;
        public bool attackInProgress = false;
        public GameObject owner;

        public float speed = .1f;

        protected float angle;

        public Vector2 attackDirection = new Vector2(0, 1);

        private void Awake()
        {
        }

        private void Update()
        {
            if (!attackInProgress)
                return;

            transform.Translate(attackDirection * speed * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (!LayerHelper.LayerInLayerMask(collision.gameObject.layer, targets))
                return;

            attackInProgress = false;

            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!LayerHelper.LayerInLayerMask(collision.gameObject.layer, targets))
                return;

            attackInProgress = false;

            gameObject.SetActive(false);
        }

        public void OnShot()
        {
            attackInProgress = true;
            var damageOnTouch = gameObject.GetComponent<DamageOnTouch>();

            damageOnTouch.targetLayerMask = targets;
            damageOnTouch.owner = owner;

            transform.position = owner.transform.position;
            transform.rotation = owner.transform.rotation;

            gameObject.SetActive(true);
        }
    }
}
