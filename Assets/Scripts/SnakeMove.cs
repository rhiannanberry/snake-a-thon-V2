using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour {
    public float maxSpeed = 5f;
    public float acceleration = 0.5f;
    private float speed = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        speed = Mathf.Clamp((speed + acceleration), 0f, maxSpeed);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = mousePos - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        transform.position = Vector2.MoveTowards(transform.position, mousePos, Time.deltaTime * speed);
	}
}
