using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_BackgroundObject : MonoBehaviour {

    public GameObject target;
    public float parallaxScale;

    private float x;
    private float y;
    private float targetdPosX;
    private float targetdPosY;
    private float oldtargetPosX;
    private float oldtargetPosY;

	// Use this for initialization
	void Start () {
        oldtargetPosX = target.transform.position.x;
        oldtargetPosY = target.transform.position.y;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        targetdPosX = target.transform.position.x - oldtargetPosX;
        targetdPosY = target.transform.position.y - oldtargetPosY;
        x = transform.position.x - targetdPosX * parallaxScale;
        y = transform.position.y - targetdPosY * parallaxScale;
        transform.position = new Vector3(x, y);
        oldtargetPosX = target.transform.position.x;
        oldtargetPosY = target.transform.position.y;
    }
}
