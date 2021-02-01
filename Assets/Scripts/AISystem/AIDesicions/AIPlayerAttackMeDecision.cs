using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AISystem.AIDesicions
{
    public class AIPlayerAttackMeDecision : AIDecision
    {
        public LayerMask layerHits;

        protected bool playerHitMe = false;

        public override bool Decide()
        {
            return playerHitMe;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!LayerHelper.LayerInLayerMask(collision.gameObject.layer, layerHits))
                return;

            playerHitMe = true;            
        }
    }
}
