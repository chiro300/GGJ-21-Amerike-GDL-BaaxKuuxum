using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AISystem
{
    public abstract class AIAction : MonoBehaviour
    {
        public AITransition[] transitions;

        public abstract void Action();

        public abstract void ExitAction();

    }
}
