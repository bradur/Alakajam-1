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

    void Start () {
    
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
        armsSr.enabled = false;
        crossBowArmsSr.enabled = true;
        CrossbowBoltManager.main.SpawnBolt(boltPosition.position, transform.rotation);
    }

    public void StopShooting()
    {
        armsSr.enabled = true;
        crossBowArmsSr.enabled = false;
    }
}
