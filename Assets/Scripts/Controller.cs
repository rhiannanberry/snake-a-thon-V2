using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class Controller : MonoBehaviour
{
    
    public GameObject headPrefab;
    public Transform foodPrefab;
    public int currentPalette = 0;

    public List<Palette> palettes = new List<Palette>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Persistent");
        if (objs.Length >= 3) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnFood(GameObject head, int pieces)
    {
        //32 across
        for (int i = 0; i < pieces; i++)
        {
            Vector2 loc = Tools.randomInRange();
            while (Vector2.Distance(loc, head.transform.position) < 3)
            {
                loc = Tools.randomInRange();
            }
            Transform food = Instantiate(foodPrefab, loc, Quaternion.identity);
        }
    }
    public void LoadScene(int scene) {
        SceneManager.LoadScene(scene);
        
    }

    public Palette getCurrentPalette() {
        return palettes[currentPalette];
    }
    public void setCurrentPalette(int num) {
        currentPalette = num;
        GameObject.Find("Foreground").GetComponent<Tilemap>().color = palettes[currentPalette].main;
        GameObject.Find("Background").GetComponent<Tilemap>().color = palettes[currentPalette].secondary;
        GameObject canvas = GameObject.Find("Canvas");
        Text[] text = GameObject.Find("Canvas").GetComponentsInChildren<Text>();
        foreach (Text txt in text) {
            txt.color = palettes[currentPalette].main;
        }
        //GameObject[] pageSelectChildren = GameObject.Find("PageSelect").transform.getChi
        //Text[] text = GameObject.Find("PageSelect").GetComponentInChildren<Text>();

    }

}
