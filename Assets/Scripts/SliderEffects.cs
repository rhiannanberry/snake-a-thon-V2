using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEffects : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Palette colors = GameObject.Find("Controller").GetComponent<Controller>().getCurrentPalette();
        ColorBlock colorBlock = new ColorBlock();
        colorBlock.normalColor = colors.main;
        colorBlock.pressedColor = colors.main;
        colorBlock.highlightedColor = colors.main;
        colorBlock.colorMultiplier = 1;
        gameObject.GetComponentInChildren<Image>().color = colors.main;
        gameObject.GetComponent<Slider>().colors = colorBlock;
        gameObject.GetComponent<Slider>().fillRect.GetComponent<Image>().color = colors.main;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
