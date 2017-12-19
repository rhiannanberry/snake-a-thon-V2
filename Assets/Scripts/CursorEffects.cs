using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorEffects : MonoBehaviour {
    private float z;
	// Use this for initialization
	void Start () {
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousexy = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousexy.x, mousexy.y, z);
    }
}
