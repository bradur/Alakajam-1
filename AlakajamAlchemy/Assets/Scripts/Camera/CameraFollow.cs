// Date   : 23.09.2017 12:55
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private int roundToDecimals = 2;

    [SerializeField]
    private Vector2 clampMin;
    [SerializeField]
    private Vector2 clampMax;

    void Start () {
    
    }

    void Update () {
        Vector3 newPos = target.position;
        newPos.z = transform.position.z;
        newPos.x = (float)System.Math.Round(newPos.x, roundToDecimals);
        newPos.y = (float)System.Math.Round(newPos.y, roundToDecimals);
        newPos.x = Mathf.Clamp(newPos.x, clampMin.x, clampMax.x);
        newPos.y = Mathf.Clamp(newPos.y, clampMin.y, clampMax.y);
        transform.position = newPos;
    }
}
