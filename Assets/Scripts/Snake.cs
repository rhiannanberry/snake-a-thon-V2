using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is where the stats are held
public class Snake : MonoBehaviour {

    public GameObject snakeBody;
    public List<GameObject> bodyParts = new List<GameObject>();

    //private external references
    Controller controller;


    //stats
    public float maxSpeed = 5f;
    public float currentSpeed = 0f;
    public float acceleration = 0.5f;
    public float rotationDebuff = 0f;
    public int score = 0;
    public float runTime = 0f;
    public float distance = 0f;
    //this will also include a list of number of each food
    

    // Use this for initialization
    void Start () {
        controller = GameObject.Find("Controller").GetComponent<Controller>();
        controller.StartRun();
	}
	
	// Update is called once per frame
	void Update () {
        //Move
        Move();

        //update stats like runtime and distance
        UpdatePerFrameStats();

		//check acheivements
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Food") {
            //add to score ammendum: Score should not be _set_ in ui, only referenced
            //add a method to ui to pull stats from here to update
            score++;
            collision.gameObject.GetComponent<Food>().Eat(gameObject);
    
            GameObject newBody;
            if (bodyParts.Count == 0) {
                newBody = Instantiate(snakeBody, transform.position - transform.up, transform.rotation);
            } else {
                GameObject prevTail = bodyParts[bodyParts.Count - 1];
                newBody = Instantiate(snakeBody, prevTail.transform.position - transform.up, prevTail.transform.rotation);
            }

            foreach (GameObject food in GameObject.FindGameObjectsWithTag("Food")) {
                Destroy(food);
            }
            controller.spawnFood(transform.position, Random.Range(1, 4));
        } else {
            controller.EndRun(gameObject);
        }
    }

    public void Kill() {
        foreach (GameObject food in GameObject.FindGameObjectsWithTag("Food")) {
            Destroy(food);
        }
        foreach (GameObject body in bodyParts) {
            Destroy(body);
        }
        Destroy(gameObject);
    }

    private void Move() {
        currentSpeed = Mathf.Clamp((currentSpeed + acceleration), 0f, maxSpeed);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = mousePos - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        transform.position = Vector2.MoveTowards(transform.position, mousePos, Time.deltaTime * currentSpeed);
    }

    private void UpdatePerFrameStats() {
        runTime += Time.deltaTime;
    }
}
