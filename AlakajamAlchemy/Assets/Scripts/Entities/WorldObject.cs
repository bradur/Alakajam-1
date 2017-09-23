// Date   : 23.09.2017 02:57
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;

public enum ObjectType
{
    None,
    Spawn
}

public class WorldObject : MonoBehaviour {

    private ObjectType objectType;

    [SerializeField]
    private int unitSize = 64;

    public void Init(int type, TiledSharp.TmxObjectGroup.TmxObject worldObject)
    {
        objectType = (ObjectType)type;
        if (objectType == ObjectType.Spawn)
        {
            PlayerManager.main.SpawnPlayer(new Vector3(
                (float) worldObject.X / unitSize,
                -(float) worldObject.Y / unitSize - 4,
                0f
            ));
        }
    }

    void Start () {
    
    }

    void Update () {
    
    }
}
