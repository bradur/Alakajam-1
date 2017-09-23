// Date   : 23.09.2017 16:30
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

    [SerializeField]
    [Range(1, 50)]
    private int hitPoints = 5;

    public void GetHit(DamageSource damageSource)
    {
        if (damageSource == null)
        {
            return;
        }
        hitPoints -= damageSource.Damage;
        if (hitPoints <= 0)
        {
            Die(damageSource.Type);
        }
    }

    void Die (DamageType type)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        GetHit(collider.GetComponent<DamageSource>());
    }
}
