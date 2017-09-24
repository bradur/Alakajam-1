// Date   : 24.09.2017 19:34
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class PlayerThrow : MonoBehaviour {

    [SerializeField]
    Transform boltPosition;

    PlayerInventoryManager pim;

    void Start()
    {
        pim = GetComponent<PlayerInventoryManager>();
    }

    void Update()
    {
        if (KeyManager.main.GetKeyDown(Action.UsePotion))
        {
            Throw();
        }
        if (KeyManager.main.GetKeyUp(Action.UsePotion))
        {
            StopThrowing();
        }
    }

    public void Throw()
    {
        if (pim.CanConsume(ItemType.LovePotion) && UIManager.main.UseHotBarItem(HotbarItem.Potion))
        {
            pim.ConsumeOne(ItemType.LovePotion);
            /*armsSr.enabled = false;
            crossBowArmsSr.enabled = true;*/
            CrossbowBoltManager.main.SpawnBolt(boltPosition.position, boltPosition.rotation, true);
        }
    }

    public void StopThrowing()
    {
    }
}
