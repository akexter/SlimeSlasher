using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToMenu : MonoBehaviour
{
    float startPos;
    Rigidbody2D rb;
    public bool canDestroy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = Mathf.Round(Random.Range(1, 4));
        DontDestroyOnLoad(gameObject);

        if (startPos == 1f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 29.7f);
        }
        if (startPos == 2f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 29.7f);
        }
        if (startPos == 3f)
        {
            transform.position = new Vector2(transform.position.x + 52.8f, transform.position.y);
        }
        if (startPos == 4f)
        {
            transform.position = new Vector2(transform.position.x - 52.8f, transform.position.y);
        }
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= 9f)
        {
            canDestroy = true;

            if (startPos == 1f)
            {
                rb.velocity = new Vector2(0f, -29.7f);
            }
            if (startPos == 2f)
            {
                rb.velocity = new Vector2(0f, 29.7f);
            }
            if (startPos == 3f)
            {
                rb.velocity = new Vector2(-52.8f, 0f);
            }
            if (startPos == 4f)
            {
                rb.velocity = new Vector2(52.8f, 0f);
            }
        }
        if (Time.timeSinceLevelLoad >= 3f && Time.timeSinceLevelLoad < 9f && canDestroy == true)
        {
            Destroy(gameObject);
        }
    }
}
