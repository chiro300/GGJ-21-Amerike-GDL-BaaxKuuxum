using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AISystem
{
    public abstract class AIDecision : MonoBehaviour
    {
        public abstract bool Decide();
    }
}
