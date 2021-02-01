using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AISystem.AIDesicions
{
    public class AITestDesicion : AIDecision
    {
        public bool decide;

        public override bool Decide()
        {
            return decide;
        }
    }
}
