using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class HealthItem : MonoBehaviour
    {

        public LayerMask target;

        public int live = 1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (LayerHelper.LayerInLayerMask(collision.gameObject.layer, target))
            {
                collision.GetComponent<Health>().AddHealth(live);

                gameObject.SetActive(false);
            }
        }
    }
}
