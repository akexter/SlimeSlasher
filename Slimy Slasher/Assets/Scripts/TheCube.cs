using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCube : MonoBehaviour
{
    float startPos;
    public GameObject player;
    void Start()
    {
        startPos = transform.position.y;
        player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x, startPos + (Mathf.Sin(Time.time) / 4));
        transform.rotation = new Quaternion((Mathf.Sin(Time.time)), (Mathf.Sin(Time.time)), 0, transform.rotation.w);
    }
}
