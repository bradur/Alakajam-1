// Date   : 23.09.2017 21:35
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIInventoryManager : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    [SerializeField]
    private UIInventoryItem inventoryItemPrefab;

    [SerializeField]
    private Transform container;

    [SerializeField]
    [Range(2f, 50f)]
    private float marginY = 10f;

    [SerializeField]
    private List<UIInventoryItem> items;

    public void UpdateItemCount (InventoryItem item, int count)
    {
        UIInventoryItem inventoryItem = GetItem(item);
        inventoryItem.UpdateCount(count);
    }

    public void AddItem (InventoryItem newItem)
    {
        UIInventoryItem item = Instantiate(inventoryItemPrefab);
        item.transform.SetParent(container);
        RectTransform rt = item.GetComponent<RectTransform>();
        item.Init(newItem);
        items.Add(item);
        RenderItems();
    }

    public UIInventoryItem GetItem (InventoryItem item)
    {
        foreach(UIInventoryItem inventoryItem in items)
        {
            if (inventoryItem.Item == item)
            {
                return inventoryItem;
            }
        }
        return null;
    }

    public void RemoveItem(InventoryItem item)
    {
        if (item.type != ItemType.Bolt && item.type != ItemType.LovePotion) { 
            UIInventoryItem uiInventoryItem = GetItem(item);
            items.Remove(uiInventoryItem);
            uiInventoryItem.Kill();
            RenderItems();
        }
    }

    void RenderItems ()
    {
        var index = 0;
        foreach(UIInventoryItem item in items)
        {
            RectTransform rt = item.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(0f, -(index * rt.sizeDelta.y + index * marginY + marginY));
            index += 1;
        }
    }

}
