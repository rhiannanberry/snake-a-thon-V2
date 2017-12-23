using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorEffects : MonoBehaviour {
    private float z;
    private Color clr;
    // Use this for initialization
    void Start() {
        z = transform.position.z;
        SetCursorColor(GameObject.Find("Controller").GetComponent<Controller>().getCurrentPalette().main);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousexy = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousexy.x, mousexy.y, z);
    }

    public void SetCursorColor(Color clr) {
        var main = GetComponent<ParticleSystem>().main;
        main.startColor = clr;

        var lifeTime = GetComponent<ParticleSystem>().colorOverLifetime;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(clr, 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        lifeTime.color = grad;
    }
}
