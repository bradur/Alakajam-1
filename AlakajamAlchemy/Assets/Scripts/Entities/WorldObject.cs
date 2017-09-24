// Date   : 23.09.2017 02:57
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;

public enum ObjectType
{
    None,
    Spawn,
    Object
}

public class WorldObject : MonoBehaviour {

    private ObjectType objectType;

    [SerializeField]
    private int unitSize = 64;

    public void Init(string objectName, int type, TiledSharp.TmxObjectGroup objectGroup)
    {
        objectType = (ObjectType)type;
        foreach (TiledSharp.TmxObjectGroup.TmxObject worldObject in objectGroup.Objects) {
            if (objectType == ObjectType.Spawn)
            {
                PlayerManager.main.SpawnPlayer(new Vector3(
                    (float) worldObject.X / unitSize,
                    -(float) worldObject.Y / unitSize - 1f,
                    0f
                ));
            } else if (objectType == ObjectType.Object)
            {
                GameObject spawnThisObjectHere = Instantiate((GameObject)Resources.Load(objectName));
                spawnThisObjectHere.transform.SetParent(transform);
                spawnThisObjectHere.transform.position = new Vector3 (
                    (float)worldObject.X / unitSize,
                    -(float)worldObject.Y / unitSize,
                    0f
                );
            }
        }
    }

    void Start () {
    
    }

    void Update () {
    
    }
}
