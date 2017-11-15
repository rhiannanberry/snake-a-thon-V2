using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AchievementChecker {


    //runs when you eat food
    public static bool ScoreCheck(int currentScore, int scoreBound, int achievementNum)
    {
        return currentScore >= scoreBound;
    }

    public static bool TimeCheck(float currentTime, float timeBound, int achievementNum)
    {
        return currentTime >= timeBound;
    }

    public static bool DeathCheck(int currentDeath, int deathBound, int achievementNum)
    {
        return currentDeath >= deathBound;
    }
}
