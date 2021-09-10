using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer m_Spriterenderer;
    public LayerMask layerMask;

    public float lastAction;
    public float velocityX;
    public float nextAction;
    public float xMax;
    public float xMin;
    public Vector2 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Spriterenderer = GetComponent<SpriteRenderer>();
        lastAction = 0f;
        nextAction = 0f;
        startPos = transform.position;
    }

    void Update()
    {
        if (rb.velocity.x < 0)
        {
            m_Spriterenderer.flipX = true;
        }
        if (rb.velocity.x > 0)
        {
            m_Spriterenderer.flipX = false;
        }

        Movement();
    }

    void Movement()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, Mathf.Infinity, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, Mathf.Infinity, layerMask);

        if (hit.distance <= 1f && hit.distance > 0 || hit2.distance <= 1f && hit.distance > 0)
        {
            rb.velocity = new Vector2(-velocityX, 0f);
        }

        if (Time.time >= lastAction + nextAction - 1)
        {
            rb.velocity = new Vector2(0f, 0f);
        }

        if (Time.time >= lastAction + nextAction)
        {
            velocityX = Mathf.Round(Random.Range(-1f, 1f)) * Mathf.Round(Random.Range(1f, 2f));
            if (velocityX == 0)
            {
                Movement();
            }
            rb.velocity = new Vector2(velocityX, 0f);
            lastAction = Time.time;
            nextAction = Mathf.Round(Random.Range(3f, 6f));
        }
        if (transform.position.x >= startPos.x + xMax || transform.position.x <= startPos.x - xMin)
        {
            rb.velocity = new Vector2(-velocityX, 0f);
        }

        if (transform.position.x >= startPos.x + xMax + 1 || transform.position.x <= startPos.x - xMin - 1)
        {
            transform.position = startPos;
        }

        if (GetComponent<EnemyHealth>().hurt == true)
        {
            rb.velocity = new Vector2(0f, 0f);
            lastAction = Time.time;
            nextAction = Mathf.Round(Random.Range(3f, 6f));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(startPos, new Vector2(startPos.x + xMax, startPos.y));
        Gizmos.DrawLine(startPos, new Vector2(startPos.x - xMin, startPos.y));
    }
}
