using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Tools {
    private static Vector2 botLeft = new Vector2(0,0);
    private static Vector2 topRight = new Vector2(0, 0);

    private static void getScreenBounds()
    {
        botLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
        Debug.Log(botLeft.ToString() + " " + topRight.ToString());
    }

    public static Vector2 randomInRange(Vector2 bl, Vector2 tr)
    {
        float randx = Random.Range(bl.x, tr.x);
        float randy = Random.Range(bl.y, tr.y);
        //in the future account for food width
        return new Vector2(randx, randy);
    }

    public static Vector2 randomInRange()
    {
        if (botLeft == topRight)
        {
            getScreenBounds();
        }
        float wallWidth = (topRight.x - botLeft.x) / 32;
        float randx = Random.Range(botLeft.x+wallWidth, topRight.x-wallWidth);
        float randy = Random.Range(botLeft.y+wallWidth, topRight.y-wallWidth);
        //in the future account for food width
        return new Vector2(randx, randy);
    }
}
