using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyMove : MonoBehaviour {
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("SnakeHead");
    }

    // Update is called once per frame
    void Update () {
        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        if (Vector2.Distance(player.transform.position, transform.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * player.GetComponent<SnakeMove>().speed);
        }
    }
}
