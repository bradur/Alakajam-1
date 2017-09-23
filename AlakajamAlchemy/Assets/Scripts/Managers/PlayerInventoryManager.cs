// Date   : 23.09.2017 17:04
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

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

    public bool CanConsume(ItemType itemType)
    {
        InventoryItem item = InventoryManager.main.GetItem(itemType);
        if (item != null && item.count > 0)
        {
            return true;
        }
        return false;
    }
}
