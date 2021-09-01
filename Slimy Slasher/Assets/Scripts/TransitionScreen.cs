using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScreen : MonoBehaviour
{
    public Button leftClick;
    public float clickTime;
    float startPos;
    Rigidbody2D rb;

    void Start()
    {
        leftClick.onClick.AddListener(TaskOnClick);
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
        startPos = Mathf.Round(Random.Range(1, 4));

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
    void TaskOnClick()
    {
        clickTime = Time.time;
    }
    void Update()
    {
        if (clickTime != 0)
        {
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

        if (Time.time >= clickTime + 4f && clickTime != 0)
        {
            Destroy(gameObject);
        }
    }
}
