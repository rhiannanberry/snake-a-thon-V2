using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteEffects : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Palette colors = GameObject.Find("Controller").GetComponent<Controller>().getCurrentPalette();
        transform.GetComponent<SpriteRenderer>().color = colors.main;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
