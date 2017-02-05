using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteSorter;



public class World : MonoBehaviour {

    //Public variables
    [Header("World Settings:")]
    public TextAsset WorldMap;
    public int sizex;
    public int sizey;
    [Space(2)]
    [Header("Prefabs:")]
    public GameObject Empty;
    public GameObject Wall;
    public GameObject WallCorner;
    public GameObject WallCornerSide;
    public GameObject WallCornerUp;
    public GameObject WallEnd;
    public GameObject WallEndUp;
    public GameObject WallPillar;
    public GameObject Top;
    public GameObject Floor;
    //Private variables
    private string[,] wa;
    private GameObject wt;
    private GameObject ft;

    // Use this for initialization
    void Start () {
        wa = new string[sizex, sizey];
        wa = ParseTextAsset(WorldMap, sizex, sizey);
        for (int y = 0; y < sizey; y++)
        {
            for (int x = 0; x < sizex; x++)
            {
                if (wa[x, y] == "1")
                {
                    ft = Instantiate(Floor, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
                    ft.GetComponent<SpriteRenderer>().sortingLayerName = "Floor";
                }
                else if (wa[x, y] == "2")
                {
                    ft = Instantiate(Floor, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
                    ft.GetComponent<SpriteRenderer>().sortingLayerName = "Floor";
                    SelectWallPrefab(x,y);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static string[,] ParseTextAsset(TextAsset wm, int X, int Y)
    {
        string[,] wmArray = new string[X, Y];
        string[] ws = wm.text.Split(';');
        string[] wc;
        for (int y = 0; y < ws.Length; y++) {
            wc = ws[y].Split(',');         //First we split the map file into the Y layers and specify the divider
            for (int x = 0; x < wc.Length; x++) {
                wmArray[x, y] = wc[x];//Then we split the Y layers into the individual X values and add it to the correct location in the World Map Array
            }
        }
        return wmArray;
    }

    public void SelectWallPrefab(int x, int y) {
        if (wa[x + 1, y] != "2" && wa[x - 1, y] != "2" && wa[x, y - 1] != "2" && wa[x, y + 1] != "2")
        {
            wt = Instantiate(WallPillar, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().Flip(wt);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else if (wa[x + 1, y] == "2" && wa[x, y - 1] == "2")
        {
            wt = Instantiate(WallCorner, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else if (wa[x - 1, y] == "2" && wa[x, y + 1] == "2")
        {
            wt = Instantiate(WallCornerUp, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else if (wa[x - 1, y] != "2" && wa[x + 1, y] == "2" && wa[x, y - 1] != "2" && wa[x, y + 1] != "2")
        {
            wt = Instantiate(WallEnd, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else if (wa[x + 1, y] != "2" && wa[x - 1, y] != "2" && wa[x, y - 1] == "2" && wa[x, y + 1] != "2")
        {
            wt = Instantiate(WallEnd, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().Flip(wt);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else if (wa[x - 1, y] != "2" && wa[x + 1, y] != "2" && wa[x, y - 1] != "2" && wa[x, y + 1] == "2")
        {
            wt = Instantiate(WallEndUp, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else if (wa[x + 1, y] != "2" && wa[x - 1, y] == "2" && wa[x, y - 1] != "2" && wa[x, y + 1] != "2")
        {
            wt = Instantiate(WallEndUp, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().Flip(wt);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else if (wa[x - 1, y] == "2" && wa[x, y - 1] == "2")
        {
            wt = Instantiate(WallCornerSide, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().Flip(wt);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else if (wa[x + 1, y] == "2" && wa[x, y + 1] == "2")
        {
            wt = Instantiate(WallCornerSide, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else if (wa[x, y - 1] == "2" || wa[x, y + 1] == "2")
        {
            wt = Instantiate(Wall, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().Flip(wt);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        else
        {
            wt = Instantiate(Wall, new Vector3(1.28f * x + 1.28f * y, .64f * x - .64f * y, 0), Quaternion.identity);
            SpriteSorting.SortByY(wt, 4);
            wt.GetComponent<WallScript>().x = x;
            wt.GetComponent<WallScript>().y = y;
            wt.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
    }

}
