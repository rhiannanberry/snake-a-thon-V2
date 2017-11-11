using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSelector : MonoBehaviour {

    int current, total;
    GameObject grid;
	// Use this for initialization
	void Start () {
        grid = GameObject.Find("PaletteGrid");
        setCurrent(1);
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(BackOnClick);
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(ForwardOnClick);

    }

    // Update is called once per frame
    void Update () {
		
	}

    void BackOnClick() {
        if (current > 1) {
            current--;
            setCurrent(current);
            grid.GetComponent<PaletteGrid>().DrawGridPage(current-1);
            //refresh grid
        }
    }

    void ForwardOnClick() {
        if (current < total) {
            current++;
            setCurrent(current);
            grid.GetComponent<PaletteGrid>().DrawGridPage(current-1);

            //refresh grid
        }
    }

    private void setCurrent(int cnt) {
        current = cnt;
        transform.GetChild(3).GetComponent<Text>().text = cnt.ToString();
    }
    public void setTotal(int cnt) {
        total = cnt;
        transform.GetChild(4).GetComponent<Text>().text = cnt.ToString();
    }
}
