using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AISystem.AIActions
{
    public class AITestAction : AIAction
    {
        public string messageAction;

        public override void Action()
        {
            Debug.Log(messageAction);
        }

        public override void ExitAction()
        {
            
        }
    }
}
