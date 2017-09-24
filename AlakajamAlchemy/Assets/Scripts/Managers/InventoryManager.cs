// Date   : 23.09.2017 21:47
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

    public static InventoryManager main;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("InventoryManager").Length == 0)
        {
            main = this;
            gameObject.tag = "InventoryManager";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private List<InventoryItem> items;

    void Start ()
    {
        foreach (InventoryItem item in items)
        {
            UIManager.main.AddItem(item);
        }
    }

    public InventoryItem GetItem(ItemType itemType)
    {
        foreach(InventoryItem item in items)
        {
            if (item.type == itemType)
            {
                return item;
            }
        }
        return null;
    }

    public void AddItem (ItemType itemType)
    {
        InventoryItem item = GetItem(itemType);
        if (item != null)
        {
            item.count += 1;
            UIManager.main.UpdateItemCount(item, item.count);
        } else
        {
            item = ItemManager.main.GetItem(itemType);
            items.Add(item);
            UIManager.main.AddItem(item);
        }
    }

    public void ConsumeItem (ItemType itemType)
    {
        InventoryItem item = GetItem(itemType);
        if (item != null)
        {
            item.count -= 1;
            UIManager.main.UpdateItemCount(item, item.count);
            if (item.count <= 0)
            {
                RemoveItem(item);
            }
            
        }
    }

    public void RemoveItem (InventoryItem item)
    {
        items.Remove(item);
        UIManager.main.RemoveItem(item);
    }
}
