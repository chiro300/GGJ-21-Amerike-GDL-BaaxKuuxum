using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.AISystem.AIDesicions
{
    public class AIEventDesicion : AIDecision
    {
        protected bool eventExecuted = false;

        public override bool Decide()
        {
            return eventExecuted;
        }

        public void EventListener()
        {
            eventExecuted = true;
        }
    }
}
