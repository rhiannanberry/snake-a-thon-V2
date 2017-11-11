using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEffects : MonoBehaviour {

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Persistent");
        if (objs.Length >= 3) {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
