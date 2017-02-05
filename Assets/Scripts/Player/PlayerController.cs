using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour {

    public float Speed = 320f;
    public float movex = 0f;
    public float movey = 0f;
    public int HeightOffset = 4;

    private Rigidbody2D rb2d;
    private const int IsometricRangePerYUnit = 5;
    private float dS;


    // Use this for initialization
    void Start () {
		Debug.Log ("I'm ALIVE!");
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
            dS = Speed * Time.deltaTime;
            movex = Input.GetAxis("Horizontal");
            movey = Input.GetAxis("Vertical");
        if (movex != 0 && movey != 0) {
            rb2d.velocity = new Vector2(movex * dS, (movey / 2) * dS);
        }
        else {
            rb2d.velocity = new Vector2(movex * dS, movey * dS);
        }
    }

    // Late Update is called after we're done with update( useful for making sure we've stopped moving :D )
    void LateUpdate()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = -(int)(transform.position.y * IsometricRangePerYUnit + HeightOffset);
    }

}
