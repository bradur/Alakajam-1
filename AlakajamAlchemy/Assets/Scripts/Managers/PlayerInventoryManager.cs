// Date   : 23.09.2017 17:04
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class PlayerInventoryManager : MonoBehaviour {

    public static PlayerInventoryManager main;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("PlayerInventoryManager").Length == 0)
        {
            main = this;
            gameObject.tag = "PlayerInventoryManager";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Pickup(ItemType item)
    {
        Debug.Log(string.Format("Picked up {0}", item));
    }
}
