// Date   : 23.09.2017 00:29
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class RotateTowardsCursor : MonoBehaviour {

    [SerializeField]
    [Range(0.2f, 50f)]
    private float rotationSpeed = 1f;

    void Start () {
    
    }

    void Update () {
        // convert mouse position into world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;
    }
}
