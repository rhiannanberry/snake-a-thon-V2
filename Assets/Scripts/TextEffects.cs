using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffects : MonoBehaviour {
    public bool rainbow;
    public bool scale;
    public bool foreground;

    public Color baseColor;
    public float loopTime = 3.0f;
    public float scaleUpFactor = 1.2f;
    private float deltaTime;
    private Text word;
    private float hue, saturation, value, startScale;

	// Use this for initialization
	void Start () {
        word = gameObject.GetComponent<Text>();
        if (rainbow) {
            Color.RGBToHSV(baseColor, out hue, out saturation, out value);
            startScale = transform.localScale.x;
            deltaTime = 1.0f / loopTime;
        }
        Palette colors = GameObject.Find("Controller").GetComponent<Controller>().getCurrentPalette();
        word.color = foreground ? colors.main : colors.secondary;
        Debug.Log(word.color.ToString());
    }

	// Update is called once per frame
	void Update () {
        if (rainbow) {
            hue = (hue + deltaTime * Time.deltaTime) % 1;
            word.color = Color.HSVToRGB(hue, saturation, value);
        }
        if (scale) {
            transform.localScale = (Vector2.one * startScale) + Vector2.one * Mathf.PingPong(deltaTime * Time.time, scaleUpFactor - startScale);
        }
	}
}
