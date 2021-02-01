using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AISystem
{
    public class AITransition : MonoBehaviour
    {
        public AIDecision decision;

        public AIAction toTrue;

        public AIAction toFalse;
    }
}
