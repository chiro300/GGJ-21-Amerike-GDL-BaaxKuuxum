using Assets.Scripts.Weapons;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Behaivors
{
    public class MeleeAttackBeheivor : AttackBase 
    {
        public Vector2 damageSize = new Vector2(1, 1);
        public Vector2 areaOffset = new Vector2(1, 0);

        public float initialDelay = 0f;
        public float activeDuration = 1f;

        protected DamageOnTouch damageOnTouch;
        protected BoxCollider2D damageCollider;
        protected GameObject damageArea;

        protected Vector3 gizmoSize;
        protected Vector3 gizmoOffset;

        private void Awake()
        {
            if (damageArea == null)
            {
                CreateAttackArea();
                DisabledAttackArea();
            }

            animator = gameObject.GetComponent<Animator>();

            if (animator != null)
                attackParameterId = Animator.StringToHash(attackParameterName);
        }

        protected override IEnumerator OnAttack()
        {
            attackInProgress = true;
            animator.SetBool(attackParameterId, true);

            yield return new WaitForSeconds(initialDelay);
            EnableAttackArea();
            yield return new WaitForSeconds(activeDuration);
            DisabledAttackArea();

            attackInProgress = false;

            animator.SetBool(attackParameterId, false);
        }

        public void CreateAttackArea()
        {
            damageArea = new GameObject();
            damageArea.name = this.name + "DamageArea";

            damageArea.transform.position = transform.position;
            damageArea.transform.rotation = transform.rotation;

            damageArea.transform.SetParent(transform);

            damageCollider = damageArea.AddComponent<BoxCollider2D>();
            damageCollider.offset = areaOffset;
            damageCollider.size = damageSize;
            damageCollider.isTrigger = true;

            Rigidbody2D rigidBody = damageArea.AddComponent<Rigidbody2D>();
            rigidBody.isKinematic = true;

            damageOnTouch = damageArea.AddComponent<DamageOnTouch>();
            damageOnTouch.targetLayerMask = targetLayerMaks;
            damageOnTouch.damage = damage;
            damageOnTouch.knockDownTarget = knockDownTarget;
            damageOnTouch.owner = gameObject;
        }

        public void EnableAttackArea()
        {
            damageCollider.enabled = true;
        }

        public void DisabledAttackArea()
        {
            damageCollider.enabled = false;
        }

        protected virtual void DrawGizmos()
        {
            gizmoOffset = areaOffset;

            Gizmos.color = Color.green;
            Gizmos.DrawCube(gizmoOffset, gizmoSize);
        }

        private void OnDrawGizmos()
        {
            DrawGizmos();
        }

        protected virtual void OnDrawGizmosSelected()
        {
            DrawGizmos();
        }
    }
}