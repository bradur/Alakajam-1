// Date   : 23.09.2017 01:59
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class CrossbowBoltManager : MonoBehaviour {

    [SerializeField]
    private CrossbowBolt enemyBoltPrefab;
    [SerializeField]
    private CrossbowBolt boltPrefab;
    [SerializeField]
    private CrossbowBolt potionPrefab;
    [SerializeField]
    private Transform container;

    public static CrossbowBoltManager main;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("CrossbowBoltManager").Length == 0)
        {
            main = this;
            gameObject.tag = "CrossbowBoltManager";
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SpawnEnemyBolt(Vector3 startingPosition, Quaternion rotation)
    {
        CrossbowBolt newBolt = Instantiate(enemyBoltPrefab);
        newBolt.transform.SetParent(container, false);
        newBolt.transform.position = startingPosition;
        newBolt.transform.rotation = rotation;
        newBolt.Shoot();
    }


    public void SpawnBolt (Vector3 startingPosition, Quaternion rotation)
    {
        CrossbowBolt newBolt = Instantiate(boltPrefab);
        newBolt.transform.SetParent(container, false);
        newBolt.transform.position = startingPosition;
        newBolt.transform.rotation = rotation;
        newBolt.Shoot();
    }


    public void SpawnBolt(Vector3 startingPosition, Quaternion rotation, bool isPotion)
    {
        CrossbowBolt newBolt = Instantiate(potionPrefab);
        newBolt.transform.SetParent(container, false);
        newBolt.transform.position = startingPosition;
        newBolt.transform.rotation = rotation;
        newBolt.Shoot();
    }
}
