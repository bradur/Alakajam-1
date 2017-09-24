// Date   : 23.09.2017 17:02
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class WorldItem : MonoBehaviour {

    [SerializeField]
    private ItemType itemType;
    private SpriteRenderer sr;
    private InventoryItem item;

    [SerializeField]
    [Range(-2f, -0.1f)]
    private float randomXMin;

    [SerializeField]
    [Range(0.1f, 2f)]
    private float randomXMax;
    
    [SerializeField]
    [Range(-2f, -0.1f)]
    private float randomYMin;

    [SerializeField]
    [Range(0.1f, 2f)]
    private float randomYMax;

    public void Init (InventoryItem inventoryItem, Vector3 position, bool randomizePosition)
    {
        item = inventoryItem;
        itemType = inventoryItem.type;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = item.sprite;
        if (randomizePosition)
        {
            position.x = position.x + Random.Range(randomXMin, randomXMax);
            position.y = position.y + Random.Range(randomYMin, randomYMax);
        }
        transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (item == null)
            {
                item = ItemManager.main.GetItem(itemType);
            }
            collider.gameObject.GetComponent<PlayerInventoryManager>().Pickup(item);
            Destroy(gameObject);
        }
    }
}
