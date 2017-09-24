// Date   : 23.09.2017 17:04
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventoryManager : MonoBehaviour {

    public void Pickup(InventoryItem item)
    {
        InventoryManager.main.AddItem(item.type);
    }

    public bool ConsumeOne(ItemType itemType)
    {
        if (CanConsume(itemType))
        {
            InventoryManager.main.ConsumeItem(itemType);
            return true;
        }
        return false;
    }

    public bool CanConsume(List<InventoryItem> items)
    {
        bool success = true;
        foreach(InventoryItem item in items)
        {
            if (!CanConsume(item.type, item.count))
            {
                return false;
            }
        }
        return success;
    }

    public bool Consume(List<InventoryItem> items)
    {
        if (CanConsume(items))
        {
            foreach (InventoryItem item in items)
            {
                Consume(item.type, item.count);
            }
            return false;
        }
        return false;
    }

    public bool Consume(ItemType itemType, int count)
    {
        if (CanConsume(itemType, count))
        {
            InventoryManager.main.ConsumeItem(itemType, count);
            return true;
        }
        return false;
    }

    public bool CanConsume(ItemType itemType)
    {
        InventoryItem item = InventoryManager.main.GetItem(itemType);
        if (item != null && item.count > 0)
        {
            return true;
        }
        return false;
    }

    public bool CanConsume(ItemType itemType, int count)
    {
        InventoryItem item = InventoryManager.main.GetItem(itemType);
        if (item != null && item.count >= count)
        {
            return true;
        }
        return false;
    }
}
