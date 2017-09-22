// Date   : 23.09.2017 01:59
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class CrossbowBolt : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    [Range(0.2f, 50f)]
    private float speed;

    public void Shoot ()
    {
        rigidBody.AddForce(transform.up * speed, ForceMode2D.Force);
    }
}
