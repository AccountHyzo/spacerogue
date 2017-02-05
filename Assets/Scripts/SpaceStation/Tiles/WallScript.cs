using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteSorter;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class WallScript : MonoBehaviour {

    public int x;
    public int y;

    void Start () {
    }

    public void Flip( GameObject wall ){
        Vector3 scale = wall.transform.localScale;
        scale.x *=- 1;
        wall.transform.localScale = scale;
    }
}
