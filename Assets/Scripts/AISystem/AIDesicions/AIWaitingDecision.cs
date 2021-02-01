using System.Collections;
using Unity;
using UnityEngine;

namespace Assets.Scripts.AISystem.AIDesicions
{
    public class AIWaitingDecision : AIDecision
    {
        public float waitingSeconds = 2;

        protected AIBrain aiBrain;

        private void Awake()
        {
            aiBrain = gameObject.GetComponent<AIBrain>();
        }

        public override bool Decide()
        {
            if (aiBrain.currenActionStarted + waitingSeconds <= Time.time)
            {
                Debug.Log("Decide Waiting true" + aiBrain.currenActionStarted + " " + Time.time);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
