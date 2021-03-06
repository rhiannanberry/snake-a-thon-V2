﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.IO;


public class Controller : MonoBehaviour
{
    
    public GameObject headPrefab;
    public Transform foodPrefab;
    public int currentPalette = 0;
    public SaveData save;
    public List<Palette> palettes = new List<Palette>();

    private bool loading = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SaveLoad.Load();
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

    public void spawnFood(Vector2 location, int pieces)
    {
        //32 across
        for (int i = 0; i < pieces; i++)
        {
            Vector2 loc = Tools.randomInRange();
            while (Vector2.Distance(loc, location) < 3)
            {
                loc = Tools.randomInRange();
            }
            Transform food = Instantiate(foodPrefab, loc, Quaternion.identity);
            food.GetComponent<Food>().Randomize();
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
        transform.GetChild(0).GetComponent<CursorEffects>().SetCursorColor(palettes[currentPalette].main);
    }

    public void attachLoadData()
    {
        save = SaveLoad.saveData;
        currentPalette = save.currentPalette;
        if (!save.newSave)
        {
            palettes = save.palettes;
        }
    }

    public void addToScore(int score)
    {
        save.stats.score += score;
        save.stats.totalScore += score;
    }

    public void StartRun() {
        Camera c = Camera.main;
        Vector2 center = c.ScreenToWorldPoint(new Vector2(c.pixelWidth / 2, c.pixelHeight / 2));
        spawnFood(center, 3);
    }

    //death handler. Organizes stats acheives and destruction of snake
    public void EndRun(GameObject snake) {
        snake.GetComponent<Snake>().Kill();
        LoadScene(4);
    }

}

public static class SaveLoad {
    public static SaveData saveData = new SaveData();

    public static void Save() {
        saveData = SaveData.data;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveData.gd");
        bf.Serialize(file, SaveLoad.saveData);
        file.Close();
    }

    public static void Load() {
        if (File.Exists(Application.persistentDataPath + "/saveData.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveData.gd", FileMode.Open);
            saveData = (SaveData)bf.Deserialize(file);
            
        } else {
            //new game new life. 
            Debug.Log("Wow no file, im shocked");
        }
    }
}