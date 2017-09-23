// Date   : 23.09.2017 19:27
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ItemType
{
    None,
    Bolt,
    BunnyFoot
}

[System.Serializable]
public class InventoryItem : System.Object
{
    public string name;
    public Sprite sprite;
    public int value = 1;
    public ItemType type;
}

public class ItemManager : MonoBehaviour
{


    public static ItemManager main;

    [SerializeField]
    private WorldItem worldItemPrefab;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("ItemManager").Length == 0)
        {
            main = this;
            gameObject.tag = "ItemManager";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private List<InventoryItem> items;

    public InventoryItem GetItem(ItemType type)
    {
        foreach (InventoryItem item in items)
        {
            if (item.type == type)
            {
                return item;
            }
        }
        return null;
    }

    public void DropItems(List<ItemType> itemsToDrop, Vector3 position, bool randomizePosition)
    {
        foreach (ItemType itemType in itemsToDrop)
        {
            WorldItem worldItem = Instantiate(worldItemPrefab);
            worldItem.transform.SetParent(transform);
            worldItem.Init(GetItem(itemType), position, randomizePosition);
        }
    }
}