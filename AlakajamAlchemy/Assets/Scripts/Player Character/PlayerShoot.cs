// Date   : 23.09.2017 01:33
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    SpriteRenderer armsSr;
    [SerializeField]
    SpriteRenderer crossBowArmsSr;

    [SerializeField]
    Transform boltPosition;

    PlayerInventoryManager pim;

    void Start()
    {
        pim = GetComponent<PlayerInventoryManager>();
    }

    void Update ()
    {
        if (KeyManager.main.GetKeyDown(Action.ShootBow))
        {
            Shoot();
        }
        if (KeyManager.main.GetKeyUp(Action.ShootBow))
        {
            StopShooting();
        }
    }

    public void Shoot()
    {
        if (pim.CanConsume(ItemType.Bolt) && UIManager.main.UseHotBarItem(HotbarItem.Right))
        {
            pim.ConsumeOne(ItemType.Bolt);
            armsSr.enabled = false;
            crossBowArmsSr.enabled = true;
            CrossbowBoltManager.main.SpawnBolt(boltPosition.position, boltPosition.rotation);
        }
    }

    public void StopShooting()
    {
        armsSr.enabled = true;
        crossBowArmsSr.enabled = false;
    }
}
