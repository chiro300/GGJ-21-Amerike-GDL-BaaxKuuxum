using Assets.Scripts.Behaivors;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.AISystem.AIActions
{
    public class AIAttackAction : AIAction
    {
        public UnityEvent OnAttack;

        public AttackBase attackBase;

        protected GameObject target;

        private void Awake()
        {
            attackBase = gameObject.GetComponent<AttackBase>();
            target = GameObject.FindGameObjectWithTag("Player");
        }

        public override void Action()
        {
            if (attackBase.attackInProgress)
                return;

            Vector3 diff = target.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            attackBase.StartAttack();

            OnAttack?.Invoke();
        }

        public override void ExitAction()
        {
            attackBase.attackInProgress = false;            
        }
    }
}
