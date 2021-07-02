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
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, startPos + (Mathf.Sin(Time.time) / 4));
        gameObject.transform.Rotate(0f, 2f, 2f, Space.World);
    }
}
