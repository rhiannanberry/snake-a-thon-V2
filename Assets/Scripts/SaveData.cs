using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData {
    public static SaveData data;
    public Stats stats;

    public int currentPalette;
    public List<Palette> palettes;
    public bool newSave;

    public SaveData() {
        currentPalette = 0;
        newSave = true;
        //how to set palette pls tell
        stats = new Stats();
    }
}


//also store run stats here bc i suck
[System.Serializable]
public class Stats {
    //total time, total food eaten, highscore, highest time, acheivements (bool that shows locked)
    public int highScore, totalScore, deaths;
    public float totalTime, highestTime;
    //have a list of acheivements and bool on whether theyre unlocked

    //RUN STATS
    public int score;
    public float time;
    public List<int> acheivementsUnlocked;

    //ACHEIVEMENTES
    public Stats() {
        deaths = 0;
        highScore = 0;
        totalScore = 0;
        totalTime = 0f;
        highestTime = 0f;
    }
}
