using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement {
    private string name;
    private int paletteUnlock;
    private bool locked;
    private AchievementType type;

	public Achievement(string name, int paletteUnlock, AchievementType type)
    {
        this.name = name;
        this.paletteUnlock = paletteUnlock;
        this.type = type;

        locked = true;
    }

    public bool Check()
    {
        switch(type)
        {
            

        }
        return false;
    }


    private bool ScoreCheck(int currentScore, int scoreBound)
    {
        return currentScore >= scoreBound;
    }

    private bool TimeCheck(float currentTime, float timeBound)
    {
        return currentTime >= timeBound;
    }

    private bool DeathCheck(int currentDeath, int deathBound)
    {
        return currentDeath >= deathBound;
    }
}

public enum AchievementType { SCORE, TIME, DEATH };