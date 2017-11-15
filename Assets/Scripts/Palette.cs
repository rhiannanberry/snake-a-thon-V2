using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Palette {
    public string name;
    public Color main;
    public Color secondary;
    public bool locked;
    public Palette(string n, Color one, Color two, bool locked=true) {
        name = n;
        main = one;
        secondary = two;
        this.locked = locked;
    }
}
