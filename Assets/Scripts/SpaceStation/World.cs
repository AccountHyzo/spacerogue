using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class World : MonoBehaviour {

    //Public variables
    [Header("World Settings:")]
    public TextAsset WorldMap;
    [Space(2)]
    [Header("Prefabs:")]
    public GameObject Empty;
    public GameObject Floor;
    public GameObject Wall;
    //Private variables
    private List<List<GameObject>> worldTiles;

    // Use this for initialization
    void Start () {
        worldTiles = WorldCreation(WorldMap);

        int x = 0;
        int y = 0;

        foreach (List<GameObject> xAxis in worldTiles)
        {
            foreach (GameObject tile in xAxis)
            {
                // Spawn the tile listed in the list at the saved location(No rotation yet wip)
                Instantiate(tile, new Vector3(y, 0, x), Quaternion.identity);
                x++;
            }
            /*Debug.Log(y);
            Debug.Log(x);*/
            x = 0;
            y++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public List<List<GameObject>> WorldCreation(TextAsset worldMap)
    {
        // Create nested List structure to act as our memory of the world.
        List<List <GameObject>> worldList = new List<List <GameObject>>();

        foreach (string  yEntity in worldMap.text.Split(';'))
        {
            List<GameObject> xAxis = new List<GameObject>();
            foreach (string xEntity in yEntity.Split(','))
            {
                //Choose appropriate GameObject to populate the X Axis of the Multi Dimensional List Structure || 1 - Floor | 2 - Walls | etc.
                switch (xEntity)
                {
                    case "1":
                        xAxis.Add(Floor);
                        break;
                    case "2":
                        xAxis.Add(Wall);
                        break;
                    default:
                        GameObject worldTile = new GameObject();
                        xAxis.Add(worldTile);
                        break;
                }
            }
            worldList.Add(xAxis);
        }
        return worldList;

    }
}
