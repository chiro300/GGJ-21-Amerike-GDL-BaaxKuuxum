using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectableItem : MonoBehaviour
{

    public LayerMask target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerHelper.LayerInLayerMask(collision.gameObject.layer, target))
        {

            // Only one instance of any type can be added and not repeated in the inventory.
            if (!Inventory.PlayerInventory.items.ContainsKey(collision.tag))
            {
                Inventory.PlayerInventory.items.Add(collision.tag, gameObject);

                if(Inventory.PlayerInventory.items.Count >= 11)
                {
                    SceneManager.LoadScene("Win");
                }
            }

            Debug.Log("::: Inventory count: " + Inventory.PlayerInventory.items.Count);

            gameObject.SetActive(false);
        }
    }

}
