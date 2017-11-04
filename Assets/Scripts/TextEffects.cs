using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffects : MonoBehaviour {
    public Color baseColor;
    public float loopTime = 3.0f;
    private float deltaTime;
    private Text word;
    private float hue, saturation, value;

	// Use this for initialization
	void Start () {
        word = gameObject.GetComponent<Text>();
        Color.RGBToHSV(baseColor, out hue, out saturation, out value);
        deltaTime = 1.0f / loopTime;

    }

	// Update is called once per frame
	void Update () {
        hue = (hue + deltaTime*Time.deltaTime) % 1;
        word.color = Color.HSVToRGB(hue, saturation, value);
	}
}
