using Assets.Scripts.Behaivors;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class RangeCircleWeapon : AttackBase
    {
        public Bullet bullet;
        public int poolSize = 6;

        public float initialDelay = 0;
        public float delayBetweenShots = 5;
        public List<Vector2> bulletsDirection = new List<Vector2>()
        {
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(-1, 0),
            new Vector2(0, -1),
            new Vector2(1, 1),
            new Vector2(-1, -1),
        };


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
                    currentBullet.GetComponent<Bullet>().attackDirection = bulletsDirection[i];
                    bullets.Enqueue(currentBullet);
                }
            }
        }

        protected override IEnumerator OnAttack()
        {

            animator.SetBool(attackParameterId, true);
            
            for (int i = 0; i < poolSize; i++)
            { 
                var current = bullets.Dequeue();
                bullets.Enqueue(current);

                var currentBullet = current.GetComponent<Bullet>();

                if (currentBullet.attackInProgress)
                {
                    yield break;
                }

                currentBullet.OnShot();
            }

            animator.SetBool(attackParameterId, false);

            yield return new WaitForSeconds(delayBetweenShots);
            attackInProgress = false;
        }
    }
}
