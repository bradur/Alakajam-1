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
            mesh.Init(map.Width, map.Height, layer, groundMaterial, runningZ);
            runningZ -= 0.1f;
            mesh.transform.SetParent(worldContainer, false);
        }
        for (int index = 0; index < map.ObjectGroups.Count; index += 1)
        {
            TmxObjectGroup group = map.ObjectGroups[index];
            foreach (TmxObjectGroup.TmxObject groupObject in group.Objects)
            {
                WorldObject worldObject = Instantiate(worldObjectPrefab);
                worldObject.Init(
                    Tools.GetProperty(group.Properties, "Object"),
                    Tools.IntParseFast(Tools.GetProperty(group.Properties, "Type")),
                    groupObject
                );
            }
        }
    }

}
