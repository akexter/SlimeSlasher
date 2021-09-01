using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBall : MonoBehaviour
{
    Rigidbody2D rb;
    float creationTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, -0.5f) * 2);
        creationTime = Time.time;
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    void Update()
    {
        if (Time.time >= creationTime + 3f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (Time.time > creationTime + 0.1f)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
