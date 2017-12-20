using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    void OnStart() {
        //set sprite/food type here
    }
	void OnTriggerEnter(Collider2D other) {
        if (other.CompareTag("Player")) {

        }
    }
}
