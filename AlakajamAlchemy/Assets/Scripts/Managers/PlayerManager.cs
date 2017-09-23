// Date   : 23.09.2017 03:00
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform container;

    public static PlayerManager main;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("PlayerManager").Length == 0)
        {
            main = this;
            gameObject.tag = "PlayerManager";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnPlayer (Vector3 position)
    {
        player.transform.SetParent(container, false);
        player.transform.position = position;
    }
}
