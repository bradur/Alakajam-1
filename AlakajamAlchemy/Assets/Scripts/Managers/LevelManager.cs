// Date   : 23.09.2017 02:33
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using TiledSharp;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Level : System.Object
{
    public TextAsset file;
    public string name;
}


public class LevelManager : MonoBehaviour {

    [SerializeField]
    private TiledMesh tiledMeshPrefab;

    private float runningZ = 0f;

    [SerializeField]
    private Transform worldContainer;

    [SerializeField]
    private Material groundMaterial;

    [SerializeField]
    private WorldObject worldObjectPrefab;

    [SerializeField]
    private GameObject wallPrefab;

    [SerializeField]
    private GameObject waterPrefab;

    [SerializeField]
    private Transform wallContainer;

    public static LevelManager main;

    [SerializeField]
    private List<Level> levels;

    [SerializeField]
    private int levelNumber = 0;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("LevelManager").Length == 0)
        {
            main = this;
            gameObject.tag = "LevelManager";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (levels.Count >= levelNumber)
        {
            OpenLevel(levels[levelNumber]);
            levelNumber += 1;
        }
    }

    public void OpenLevel(Level level)
    {
        TextAsset mapFile = level.file;
        TmxMap map = new TmxMap(mapFile.text, "unused");
        for (int index = 0; index < map.Layers.Count; index += 1)
        {
            TmxLayer layer = map.Layers[index];
            TiledMesh mesh = Instantiate(tiledMeshPrefab);
            
            int layerType = Tools.IntParseFast(Tools.GetProperty(layer.Properties, "Type"));
            mesh.name = (LayerType)layerType + " (Mesh)";
            if (layerType == (int)LayerType.Ground)
            {
                mesh.Init(map.Width, map.Height, layer, groundMaterial, runningZ, null, null);
            }
            else if (layerType == (int)LayerType.Wall)
            {
                mesh.Init(map.Width, map.Height, layer, groundMaterial, runningZ, wallPrefab, wallContainer);
            }
            else if (layerType == (int)LayerType.Water)
            {
                mesh.Init(map.Width, map.Height, layer, groundMaterial, runningZ, waterPrefab, wallContainer);
            }
            runningZ -= 0.1f;
            mesh.transform.SetParent(worldContainer, false);
            mesh.transform.position = new Vector3(transform.position.x, transform.position.y - map.Height, transform.position.x);
        }
        for (int index = 0; index < map.ObjectGroups.Count; index += 1)
        {
            TmxObjectGroup group = map.ObjectGroups[index];
            WorldObject worldObject = Instantiate(worldObjectPrefab);
            int objectType = Tools.IntParseFast(Tools.GetProperty(group.Properties, "Type"));
            string prefabType = Tools.GetProperty(group.Properties, "Object");
            worldObject.name = prefabType + " (ObjectContainer)";

            worldObject.Init(
                prefabType,
                objectType,
                group
            );
        }
    }

}
