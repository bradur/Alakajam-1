// Date   : 23.09.2017 16:41
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public enum DamageType
{
    None,
    Bolt,
    Sword
}

public class DamageSource : MonoBehaviour {

    [SerializeField]
    [Range(1, 50)]
    private int damage = 1;
    public int Damage { get { return damage; } }

    [SerializeField]
    private DamageType damageType;
    public DamageType Type { get { return damageType; } }
}
