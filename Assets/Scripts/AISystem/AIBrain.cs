using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.AISystem
{
    public class AIBrain : MonoBehaviour
    {
        public AIAction currentAction;

        public AIAction initialAction;

        public float? currenActionStarted = null;

        private void Awake()
        {
            if(initialAction != null)
            {
                currentAction = initialAction;
            }
        }
        
        private void FixedUpdate()
        {
            if (currenActionStarted == null)
            {
                currenActionStarted = Time.time;
            }

            currentAction.Action();

            foreach (var current in currentAction.transitions)
            {
                var result = current.decision.Decide();

                if (result && current.toTrue != null)
                {
                    currenActionStarted = Time.time;
                    currentAction.ExitAction();
                    currentAction = current.toTrue;
                }
                else if (!result && current.toFalse != null)
                {
                    currenActionStarted = Time.time;
                    currentAction.ExitAction();
                    currentAction = current.toFalse;
                }
            }
        }
    }
}
