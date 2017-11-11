using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteGrid : MonoBehaviour {
    public GameObject buttonPrefab;
    private List<Palette> palettes;
	// Use this for initialization
	void Start () {
        palettes = GameObject.Find("Controller").GetComponent<Controller>().palettes;
        GameObject.Find("PageSelect").GetComponent<PageSelector>().setTotal((int)Mathf.Ceil(palettes.Count / 16.0f));
        DrawGridPage(0);
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DrawGridPage(int start) {
        start = start * 16;
        int col = 0;
        int row = 0;
        int cnt = start;
        for (int i = start; start < 16+start; i++) {
            if (row > 3) { break; }
            Palette palette = palettes[i];
            GameObject button = Instantiate(buttonPrefab);
            button.transform.SetParent(transform);
            button.transform.localPosition = new Vector2(-115 + (76 * col), 115 - (76 * row));
            button.transform.localScale = Vector2.one;
            button.GetComponent<PaletteButton>().setPaletteButton(i, palette);
            cnt++;
            if (col == 3) {
                col = 0;
                row++;
            } else {
                col++;
            }
        }
    }
}
