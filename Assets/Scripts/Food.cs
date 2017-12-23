using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    public List<Sprite> foods = new List<Sprite>();
    private int foodNum = 0;
    void OnStart() {
        //set sprite/food type here
        
    }
	void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {

        }
    }

    public void Randomize() {
        foodNum = Random.Range(0, foods.Count);
        GetComponent<SpriteRenderer>().sprite = foods[foodNum];
    }

    public void Eat(GameObject snake) {
        switch(foodNum) {
            case 0:
                snake.GetComponent<Snake>().maxSpeed += .1f;
                break;
            case 1:
                snake.GetComponent<Snake>().maxSpeed += 1f;
                break;
            case 2:
                snake.GetComponent<Snake>().maxSpeed -= 1f;
                break;
            default:
                Debug.Log("ERROR food not found");
                break;
        }
    }
}
