using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaivors;
using UnityEngine;

namespace Assets.Scripts.AISystem.AIActions
{
    public class AIFallbackAction : AIAction
    {

        [Header("Fallback Speed")]
        public float speedMultiplier = 1f;

        public GameObject target;

        private float directionHorizontal;
        private float directionVertical;

        private WalkingBeheivor walkingBeheivor;

        void Awake()
        {
            walkingBeheivor = gameObject.GetComponent<WalkingBeheivor>();
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player");
            }
        }

        public override void Action()
        {
            FallBack();
        }

        public override void ExitAction()
        {
            walkingBeheivor.MovementSpeedMultiplier = 1f;
        }
        public void FallBack()
        {
            directionHorizontal = target.transform.position.x < transform.position.x ? 1f : -1f;
            directionVertical = target.transform.position.y < transform.position.y ? 1f : -1f;
            walkingBeheivor.MovementSpeedMultiplier = speedMultiplier;
            walkingBeheivor.SetHorizontalMove(directionHorizontal);
            walkingBeheivor.SetVerticalMove(directionVertical);
            Debug.Log("Fallback when attacked.....");
        }
    }
}