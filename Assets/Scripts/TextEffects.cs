using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffects : MonoBehaviour {
    public Color baseColor;
    public float loopTime = 3.0f;
    public float scaleUpFactor = 1.2f;
    private float deltaTime;
    private Text word;
    private float hue, saturation, value, startScale;

	// Use this for initialization
	void Start () {
        word = gameObject.GetComponent<Text>();
        Color.RGBToHSV(baseColor, out hue, out saturation, out value);
        startScale = transform.localScale.x;
        deltaTime = 1.0f / loopTime;

    }

	// Update is called once per frame
	void Update () {
        hue = (hue + deltaTime*Time.deltaTime) % 1;
        transform.localScale = (Vector2.one * startScale) + Vector2.one * Mathf.PingPong(deltaTime * Time.time, scaleUpFactor - startScale); 
        //transform.localScale = new Vector2(startScale + Mathf.PingPong(deltaTime*Time.time, scaleUpFactor - startScale), startScale + Mathf.PingPong(deltaTime *Time.time, scaleUpFactor - startScale));
        word.color = Color.HSVToRGB(hue, saturation, value);
	}
}
