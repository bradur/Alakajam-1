// Date   : 24.09.2017 19:12
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour {

    void Start () {
        animator = GetComponent<Animator>();
    }

    void Update () {
    
    }

    [SerializeField]
    Transform boltPosition;

    [SerializeField]
    SpriteRenderer armsSr;
    [SerializeField]
    SpriteRenderer crossBowArmsSr;

    private int maxBolts = 3;

    public void Shoot()
    {
        if (maxBolts > 0)
        {
            maxBolts -= 1;
            armsSr.enabled = false;
            crossBowArmsSr.enabled = true;
            CrossbowBoltManager.main.SpawnEnemyBolt(boltPosition.position, boltPosition.rotation);
        } else
        {
            StopShooting();
        }
    }

    public void StopShooting()
    {
        armsSr.enabled = true;
        crossBowArmsSr.enabled = false;
    }

    private Animator animator;

    [SerializeField]
    private SpriteRenderer arms;

    public void Swing()
    {
        animator.SetTrigger("Swing");
        arms.enabled = false;
    }

    public void StopSwing()
    {
        arms.enabled = true;
        animator.SetTrigger("StopSwinging");
    }
}
