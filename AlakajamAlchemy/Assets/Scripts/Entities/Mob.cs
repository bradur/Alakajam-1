// Date   : 23.09.2017 16:30
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mob : MonoBehaviour {

    [SerializeField]
    [Range(1, 50)]
    private int hitPoints = 5;

    [SerializeField]
    private GetHitEffect getHitEffectPrefab;

    [SerializeField]
    private List<ItemType> certainDrops;


    private void Start()
    {
    }

    public void GetHit(DamageSource damageSource)
    {
        if (damageSource == null)
        {
            return;
        }
        hitPoints -= damageSource.Damage;
        if (getHitEffectPrefab != null)
        {
            GetHitEffect getHitEffect = Instantiate(getHitEffectPrefab);
            getHitEffect.transform.position = transform.position;
            getHitEffect.transform.rotation = transform.rotation;
        }
        if (hitPoints <= 0)
        {
            Die(damageSource.Type);
        }
    }

    void DropCertainItems()
    {
        ItemManager.main.DropItems(certainDrops, transform.position, true);
    }

    void Die (DamageType type)
    {
        DropCertainItems();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        GetHit(collider.GetComponent<DamageSource>());
    }
}
