using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class Room : MonoBehaviour {
    public TextAsset RoomLayout;
    public int x = 10;
    public int y = 10;
    private Vector2 RoomArray;

    private void Start() {
        Vector2 RoomArray = new Vector2(x, y);

        Debug.Log(RoomArray);
    }
}
