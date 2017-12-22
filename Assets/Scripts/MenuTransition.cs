using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour {
    public float transitionTime = 2.0f;
    private float startTime;
    private int currentMenu = 1;
    private RectTransform menus;
    private Vector3 desiredPos;


    bool startFadeIn = true;
    private List<GameObject> menuObjects = new List<GameObject>();
    private GameObject currentMenuObj;
    private GameObject prevMenuObj;

	// Use this for initialization
	void Start () {
        menus = GetComponent<RectTransform>();
        desiredPos = menus.localPosition;

        foreach (Transform child in transform) {
            menuObjects.Add(child.gameObject);
        }
        currentMenuObj = menuObjects[0];
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Goto(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Goto(2);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Goto(3);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            Goto(4);
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            Goto(5);
        }

		//if (desiredPos != menus.localPosition || startFadeIn) {
            float fracComplete = (Time.time - startTime) / transitionTime;
            Debug.Log(fracComplete);
            menus.localPosition = Vector3.Lerp(menus.localPosition, desiredPos, fracComplete);
            if (startFadeIn) {
                FadeIn(currentMenuObj, fracComplete);
                
                if (fracComplete >= 1) {
                    startFadeIn = false;
                    
                }
            } else {
                FadeOut(prevMenuObj, fracComplete);
                FadeIn(currentMenuObj, fracComplete);
            }
       // }
	}

    public void GoNext() {
        prevMenuObj = currentMenuObj;
        currentMenuObj = menuObjects[currentMenu];
        currentMenu++;
        desiredPos.x -= 800;
        startTime = Time.time;
    }

    public void GoPrev() {
        prevMenuObj = currentMenuObj;
        currentMenu--;
        currentMenuObj = menuObjects[currentMenu-1];
        desiredPos.x += 800;
        startTime = Time.time;
    }

    public void Goto(int menuNum) {
        prevMenuObj = currentMenuObj;
        if (menuNum == 5) {
            //when you have no ach, play again menu will be below
            desiredPos.y -= 500;
        } else {
            
            desiredPos.x += 800 * (currentMenu - menuNum);
            Debug.Log(desiredPos);
        }
        currentMenu = menuNum;
        currentMenuObj = menuObjects[currentMenu - 1];
        startTime = Time.time;
    }

    private void FadeIn(GameObject menu, float fracComplete) {
        menu.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0, 1, fracComplete);
        
    }

    private void FadeOut(GameObject menu, float fracComplete) {
        menu.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, fracComplete);
    }


}
