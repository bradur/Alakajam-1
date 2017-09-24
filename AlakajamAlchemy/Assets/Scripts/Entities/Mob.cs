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

    [SerializeField]
    private bool willFlee = false;

    private  IdleNpc npc;

    [SerializeField]
    [Range(0f, 1f)]
    private float damageInterval = 0.5f;

    bool takingDamage = false;
    private float damageTimer = 0f;

    private bool breeding = false;
    [SerializeField]
    [Range(2f, 10f)]
    private float breedInterval = 2f;
    private float breedTimer = 0f;
    [SerializeField]
    [Range(1, 20)]
    private int maxBreedCount = 5;

    private void Start()
    {
        if (willFlee)
        {
            npc = GetComponent<IdleNpc>();
        }
    }

    private void Update()
    {
        if (takingDamage)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer > damageInterval)
            {
                takingDamage = false;
                damageTimer = 0f;
            }
        }
        if (breeding)
        {
            breedTimer += Time.deltaTime;
            if (breedTimer > breedInterval)
            {
                maxBreedCount -= 1;
                breedTimer = 0f;
                Breed();
                npc.RandomMove();
                if (maxBreedCount < 1)
                {
                    breeding = false;
                }
            }
        }
    }

    void Breed ()
    {
        Mob newMob = Instantiate(this);
        newMob.transform.localScale *= 0.5f;
        newMob.transform.position = transform.position - Vector3.up;
    }

    public void GetHit(DamageSource damageSource)
    {
        if (takingDamage || damageSource == null)
        {
            return;
        }
        takingDamage = true;
        hitPoints -= damageSource.Damage;
        if (getHitEffectPrefab != null)
        {
            GetHitEffect getHitEffect = Instantiate(getHitEffectPrefab);
            getHitEffect.transform.position = transform.position;
            getHitEffect.transform.rotation = transform.rotation;
        }
        Debug.Log("I took " + damageSource.Damage + " points of damage.");
        if (damageSource.Type == DamageType.Bolt)
        {
            certainDrops.Add(ItemType.Bolt);
        }
        if (hitPoints <= 0)
        {
            Debug.Log("I died because I have " + hitPoints + " HP!");
            Die(damageSource.Type);
        } else if (willFlee)
        {
            Flee((Vector2)damageSource.transform.position);
            Debug.Log("FLEEING!");
        }
    }

    void Flee(Vector2 from)
    {
        npc.Flee(from);
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
        CrossbowBolt bolt = collider.gameObject.GetComponent<CrossbowBolt>();
        if (bolt != null && bolt.IsPotion)
        {
            Debug.Log("Breeding");
            StartBreeding();
        }
    }

    void StartBreeding ()
    {
        breeding = true;
    }
}
