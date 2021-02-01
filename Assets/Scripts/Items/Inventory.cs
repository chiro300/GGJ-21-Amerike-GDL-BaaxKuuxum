using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory inventory;

    public Dictionary<string, Object> items;

    public static Inventory PlayerInventory
    {
        get
        {
            if (inventory == null)
            {
                inventory = FindObjectOfType<Inventory>();
                if (inventory == null)
                {
                    GameObject target = new GameObject();
                    inventory = target.AddComponent<Inventory>();
                }
            }
            return inventory;
        }
    }

    private void Awake()
    {
        if (items == null)
        {
            items = new Dictionary<string, Object>();
        }

        if (inventory == null)
        {
            inventory = this as Inventory;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            if (this != inventory)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public int GetInventoryCount()
    {
        return this.items.Count;
    }
}
