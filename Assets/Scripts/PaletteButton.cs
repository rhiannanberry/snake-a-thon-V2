using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PaletteButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private Palette palette;
    private int number;
    private GameObject text;
    private bool textActive = false;
    private Canvas canv;
    Controller cont;
    // Use this for initialization
    void Start () {
        transform.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        text = transform.parent.parent.GetChild(3).gameObject;
        cont = GameObject.Find("Controller").GetComponent<Controller>();
        canv = GameObject.Find("Canvas").GetComponent<Canvas>();
        



    }

    // Update is called once per frame
    void Update () {
		if (textActive) {
            float scale = canv.scaleFactor;
            Vector2 uiOff = new Vector2(-25, 0);//bottom left to center
            Vector2 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            text.transform.position = scale * WorldToCanvasPosition(canv.GetComponent<RectTransform>(), Camera.main, camPos);
        }
	}

    void TaskOnClick() {
        cont.setCurrentPalette(number);
        text.GetComponent<Text>().color = palette.secondary;
        text.GetComponent<Outline>().effectColor = palette.main;

    }

    public void OnPointerEnter(PointerEventData data) {
        text.SetActive(true);
        text.GetComponent<Text>().text = palette.name;
        textActive = true;
        text.GetComponent<Text>().color = palette.secondary;
        text.GetComponent<Outline>().effectColor = palette.main;
    }

    public void OnPointerExit(PointerEventData data) {
        text.SetActive(false);
        textActive = false;
    }


    public void setPaletteButton(int number, Palette palette) {
        this.palette = palette;
        this.number = number;
        gameObject.GetComponent<Image>().color = palette.main;
        transform.GetChild(0).GetComponent<Image>().color = palette.secondary;
    }

    private Vector2 WorldToCanvasPosition(RectTransform canvas, Camera camera, Vector2 position) {
        Vector2 temp = camera.WorldToViewportPoint(position);
        temp.x *= canvas.sizeDelta.x;
        temp.y *= canvas.sizeDelta.y;
        return temp;
    }

}
