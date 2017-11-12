using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour {
    public float maxSpeed = 5f;
    public float acceleration = 0.5f;
    public GameObject snakeBody;
    public float speed = 0f;
    private GameObject controllerObj;
    public List<GameObject> bodyParts = new List<GameObject>();
    private Controller Controller;
    private GameScreenUI ui;

	// Use this for initialization
	void Start () {
        controllerObj = GameObject.Find("Controller");
        Controller = (Controller)controllerObj.GetComponent(typeof(Controller));
        Controller.spawnFood(gameObject, 30);
        ui = GameObject.Find("Canvas").GetComponent<GameScreenUI>();
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
            //add to score
            ui.addToScore(1);
            maxSpeed += 0.5f;
            GameObject newBody;
            if (bodyParts.Count == 0)
            {
                newBody = Instantiate(snakeBody, transform.position - transform.up, transform.rotation);
            } else
            {
                GameObject prevTail = bodyParts[bodyParts.Count - 1];
                newBody = Instantiate(snakeBody, prevTail.transform.position - transform.up, prevTail.transform.rotation);
            }
           
            //bodyParts.Add(newBody);
            foreach(GameObject food in GameObject.FindGameObjectsWithTag("Food"))
            {
                Destroy(food);
            }
            Controller.spawnFood(gameObject, Random.Range(1,4));
        } else {
            foreach(GameObject body in bodyParts) {
                Destroy(body);
            }
            Destroy(gameObject);
        }
    }
}
