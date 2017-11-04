using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public Transform foodPrefab;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("SnakeHead");
        spawnFood(30);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnFood(int pieces)
    {
        //32 across
        for (int i = 0; i < pieces; i++)
        {
            Vector2 loc = Tools.randomInRange();
            while (Vector2.Distance(loc, player.transform.position) < 3)
            {
                loc = Tools.randomInRange();
            }
            Transform food = Instantiate(foodPrefab, loc, Quaternion.identity);
        }
    }
    public void LoadScene(int scene) {
        SceneManager.LoadScene(scene);
    }

}
