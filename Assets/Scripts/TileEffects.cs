using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileEffects : MonoBehaviour {

    public bool foreground;

    // Use this for initialization
    void Start () {
        Palette colors = GameObject.Find("Controller").GetComponent<Controller>().getCurrentPalette();
        gameObject.GetComponent<Tilemap>().color = foreground ? colors.main : colors.secondary;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
