using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData {
    public static SaveData data;
    public Stats stats;

    public int currentPalette;
    public List<Palette> palettes;
    public SaveData() {
        currentPalette = 0;
        //how to set palette pls tell
        stats = new Stats();
    }
}


//also store run stats here bc i suck
[System.Serializable]
public class Stats {
    //total time, total food eaten, highscore, highest time, acheivements (bool that shows locked)
    int highScore, totalScore;
    float totalTime, highestTime;
    //have a list of acheivements and bool on whether theyre unlocked

    //RUN STATS
    int score;
    float time;
    List<int> acheivementsUnlocked;

    //ACHEIVEMENTES
    public Stats() {
        highScore = 0;
        totalScore = 0;
        totalTime = 0f;
        highestTime = 0f;
    }
}
