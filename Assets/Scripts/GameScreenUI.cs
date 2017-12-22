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
        score = GameObject.Find("SnakeHead").GetComponent<Snake>().score;
        time = GameObject.Find("SnakeHead").GetComponent<Snake>().runTime; 
	}

    // Update is called once per frame
    void Update() {
        if (GameObject.Find("SnakeHead") != null) {
            time = GameObject.Find("SnakeHead").GetComponent<Snake>().runTime;
            timeText.text = System.Math.Round(time, 2).ToString();
            score = GameObject.Find("SnakeHead").GetComponent<Snake>().score;
            scoreText.text = "score: " + score.ToString();
        }
        
    }
}
