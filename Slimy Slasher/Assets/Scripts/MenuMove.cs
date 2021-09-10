using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMove : MonoBehaviour
{
    Rigidbody2D rb;
    float direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Mathf.Round(Random.Range(1, 4));
    }

    void Update() // Randomly determines what direction the backdrop of the menu should move in
    {

        if (direction == 1f)
        {
            rb.velocity = new Vector2(-0.25f, 0f);
        }
        if (direction == 2f)
        {
            rb.velocity = new Vector2(0.25f, 0f);
        }
        if (direction == 3f)
        {
            rb.velocity = new Vector2(0f, 0.25f);
        }
        if (direction == 4f)
        {
            rb.velocity = new Vector2(0f, -0.25f);
        }

        if (transform.localPosition.x <= -23.9875 || transform.localPosition.x >= 23.9875 || transform.localPosition.y >= 14.9875 || transform.localPosition.y >= 14.9875)
        {
            transform.localPosition = new Vector2(0f, 0f);
        }
    }
}
