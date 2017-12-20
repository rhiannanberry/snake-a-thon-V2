using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyMove : MonoBehaviour {
    GameObject parent;
    GameObject head;
    int position;
    // Use this for initialization
    void Start () {
        head = GameObject.Find("SnakeHead");
        List<GameObject> parts = head.GetComponent<SnakeMove>().bodyParts;
        if (parts.Count == 0)
        {
            parent = head;
        } else
        {
            parent = parts[parts.Count - 1];
        }
        position = parts.Count;
        head.GetComponent<SnakeMove>().bodyParts.Add(gameObject);
    }

    // Update is called once per frame
    void Update () {
        Vector3 diff = parent.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        float speed = head.GetComponent<SnakeMove>().speed;
        //im mostly pleased with this movement
        //just kidding i fucking hate it
        if (Vector2.Distance(parent.transform.position, transform.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, parent.transform.position, Time.deltaTime * (speed - .05f*Mathf.Log(position+1)*speed));
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, parent.transform.position, Time.deltaTime * (speed - .2f * Mathf.Log(position + 1) * speed));

        }
    }

    void Rotation() {

    }
}
