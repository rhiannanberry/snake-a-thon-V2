using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [System.Serializable]
    public struct Palette
    {
        public string name;
        public Color main;
        public Color secondary;
        public Palette(string n, Color one, Color two)
        {
            name = n;
            main = one;
            secondary = two;
        }
    }

    public Transform foodPrefab;
    GameObject player;

    public List<Palette> palette = new List<Palette>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        //adjust this based on what scene ur in
        if (SceneManager.GetActiveScene().buildIndex == 0 )
        {

        } else
        {
            player = GameObject.Find("SnakeHead");
            spawnFood(30);
        }
        
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
