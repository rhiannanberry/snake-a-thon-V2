﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour {
    public float maxSpeed = 5f;
    public float acceleration = 0.5f;
    public GameObject snakeBody;
    public float speed = 0f;
    private GameObject controllerObj;
    private Controller Controller;

	// Use this for initialization
	void Start () {
        controllerObj = GameObject.Find("Controller");
        Controller = (Controller)controllerObj.GetComponent(typeof(Controller));
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            maxSpeed += 0.5f;
            Instantiate(snakeBody, transform.position-transform.up, transform.rotation);
            foreach(GameObject food in GameObject.FindGameObjectsWithTag("Food"))
            {
                Destroy(food);
            }
            Controller.spawnFood(Random.Range(1,4));
        }
    }
}
