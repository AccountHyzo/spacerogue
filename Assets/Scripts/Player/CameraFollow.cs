using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject target;

    private Vector3 offset;
    // Use this for initialization
    void Start () {
        offset = transform.position - target.transform.position;
        Debug.Log(target.transform.position);
	}
	
	void LateUpdate () {
        if (!target)
        {
            return;
        }
        transform.position = target.transform.position + offset;
    }
}
