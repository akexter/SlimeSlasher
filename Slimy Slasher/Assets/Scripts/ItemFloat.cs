using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloat : MonoBehaviour
{
    float startPos;
    void Start()
    {
        startPos = transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x, startPos + (Mathf.Sin(Time.time) / 4));
    }
}