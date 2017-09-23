// Date   : 23.09.2017 17:02
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

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

public class WorldItem : MonoBehaviour {
    
    [SerializeField]
    private ItemType item;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInventoryManager.main.Pickup(item);
            Destroy(gameObject);
        }
    }
}
