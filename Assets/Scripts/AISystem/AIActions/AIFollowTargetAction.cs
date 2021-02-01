using Assets.Scripts.Behaivors;
using UnityEngine;

namespace Assets.Scripts.AISystem.AIActions
{
    public class AIFollowTargetAction : AIAction
    {
        public GameObject target;

        public float speedMultiplier = 2f;
        public float minimumDistance = 1;

        private WalkingBeheivor walkingBeheivor;
        private float directionHorizontal;
        private float directionVertical;

        public string walkingAnimationParameter;
        private int walkingAnimationId;
        private Animator animator;

        private void Awake()
        {
            animator = gameObject.GetComponent<Animator>();
            walkingBeheivor = gameObject.GetComponent<WalkingBeheivor>();

            if(target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player");
            }

            if (string.IsNullOrEmpty(walkingAnimationParameter))
            {
                walkingAnimationId = Animator.StringToHash(walkingAnimationParameter);
            }
        }

        public override void Action()
        {
            animator.SetBool(walkingAnimationId, animator != null && walkingAnimationId > 0);

            if (target != null && walkingBeheivor != null)
            {
                Vector3 diff = target.transform.position - transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

                if (Mathf.Abs(this.transform.position.x - target.gameObject.transform.position.x) < minimumDistance)
                {
                    directionHorizontal = 0;
                }
                else
                {
                    directionHorizontal = target.transform.position.x > transform.position.x ? 1f : -1f;
                }

                if (Mathf.Abs(this.transform.position.y - target.gameObject.transform.position.y) < minimumDistance)
                {
                    directionVertical = 0;
                }
                else
                {
                    directionVertical = target.transform.position.y > transform.position.y ? 1f : -1f;
                }

                walkingBeheivor.MovementSpeedMultiplier = speedMultiplier;
                walkingBeheivor.SetHorizontalMove(directionHorizontal);
                walkingBeheivor.SetVerticalMove(directionVertical);
            }
        }

        public override void ExitAction()
        {
            walkingBeheivor.MovementSpeedMultiplier = 1f;
            
            walkingBeheivor.SetHorizontalMove(Random.Range(-1f, 1f));
            walkingBeheivor.SetHorizontalMove(Random.Range(-1f, 1f));

            animator.SetBool(walkingAnimationId, false);
        }
    }
}