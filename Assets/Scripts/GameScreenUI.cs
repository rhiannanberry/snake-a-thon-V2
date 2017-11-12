using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenUI : MonoBehaviour {

    //this is attached to the canvas

    private int score;
    private float time;

    private Text scoreText;
    private Text timeText;

	void Start () {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        timeText = GameObject.Find("Time").GetComponent<Text>();

        score = 0;
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeText.text = System.Math.Round(time, 2).ToString();
    }

    public void setTime(int start = 0) {
        time = start;
    }

    public void addToScore(int addition) {
        score += addition;
        scoreText.text = "score: " + score.ToString();
    }
}
