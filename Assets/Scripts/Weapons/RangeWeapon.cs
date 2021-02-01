using Assets.Scripts.Behaivors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class RangeWeapon : AttackBase
    {
        public Bullet bullet;
        public int poolSize = 5;

        public float initialDelay = 0;
        public float delayBetweenShots = 5;

        protected Queue<GameObject> bullets;
        protected GameObject target;

        private void Awake()
        {
            animator = gameObject.GetComponent<Animator>();

            if (animator != null)
                attackParameterId = Animator.StringToHash(attackParameterName);

            bullets = new Queue<GameObject>();

            if (bullet != null)
            {
                for (int i = 0; i < poolSize; i++)
                {
                    var currentBullet = Instantiate(bullet.gameObject);
                    currentBullet.SetActive(false);
                    currentBullet.GetComponent<WalkingBeheivor>()?.StopWalking();
                    currentBullet.GetComponent<Bullet>().targets = targetLayerMaks;
                    currentBullet.GetComponent<Bullet>().owner = gameObject;

                    bullets.Enqueue(currentBullet);
                }
            }
        }

        protected override IEnumerator OnAttack()
        {
            //yield return new WaitForSeconds(initialDelay);

            var current = bullets.Dequeue();
            bullets.Enqueue(current);

            var currentBullet = current.GetComponent<Bullet>();
            
            if (currentBullet.attackInProgress)
            {
                yield break;
            }

            animator.SetBool(attackParameterId, true);

            currentBullet.OnShot();

            animator.SetBool(attackParameterId, false);

            yield return new WaitForSeconds(delayBetweenShots);

            attackInProgress = false;
        }
    }
}
