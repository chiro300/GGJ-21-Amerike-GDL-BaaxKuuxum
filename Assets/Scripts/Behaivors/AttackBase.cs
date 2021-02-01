using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Behaivors
{
    public abstract class AttackBase : MonoBehaviour
    {
        public int damage;
        public bool knockDownTarget;

        public bool attackInProgress = false;

        public LayerMask targetLayerMaks;

        protected Animator animator;
        public string attackParameterName;
        protected int attackParameterId;

        public virtual void StartAttack()
        {
            if (attackInProgress)
                return;

            attackInProgress = true;
            StartCoroutine(OnAttack());
        }

        protected abstract IEnumerator OnAttack();

    }
}
