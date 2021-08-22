using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    float startPos;
    public float offset;
    void Start()
    {
        startPos = transform.position.y;
        offset = Random.Range(0f, 2f);
    }
    void Update()
    {
            transform.position = new Vector2(transform.position.x, startPos + (Mathf.Sin(Time.time + offset) / 4));
    }
}