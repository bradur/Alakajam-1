// Date   : 23.09.2017 21:22
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIInventoryItem : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    [SerializeField]
    private Text txtCount;

    [SerializeField]
    private InventoryItem item;
    public InventoryItem Item { get { return item; } }

    private Animator animator;

    public void Init (InventoryItem inventoryItem)
    {
        item = inventoryItem;
        imgComponent.sprite = inventoryItem.sprite;
        txtComponent.text = item.name;
        txtCount.text = inventoryItem.count + "";
        animator = GetComponent<Animator>();
    }

    public void UpdateCount (int count)
    {
        txtCount.text = count + "";
    }

    public void Remove ()
    {
        animator.SetTrigger("Remove");
    }

    public void Kill ()
    {
        Destroy(gameObject);
    }
}
