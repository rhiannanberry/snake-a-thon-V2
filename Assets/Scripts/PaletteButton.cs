using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaletteButton : MonoBehaviour {
    private Palette palette;
    private int number;
	// Use this for initialization
	void Start () {
        transform.GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick() {
        GameObject.Find("Controller").GetComponent<Controller>().setCurrentPalette(number);
    }

    public void setPaletteButton(int number, Palette palette) {
        this.palette = palette;
        this.number = number;
        gameObject.GetComponent<Image>().color = palette.main;
        transform.GetChild(0).GetComponent<Image>().color = palette.secondary;
    }

}
