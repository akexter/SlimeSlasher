using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    float beforeHitHealth;
    float lastHit;
    float transparencyChange;

    bool transparent;
    public bool hit;

    SpriteRenderer m_Spriterenderer;
    Rigidbody2D rb;

    void Start()
    {
        health = 3;
        maxHealth = 3;
        beforeHitHealth = health;
        rb = GetComponent<Rigidbody2D>();
        m_Spriterenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("spikes") && Time.time >= lastHit + 2f)
        {
            hit = true;
            health -= 1;
            lastHit = Time.time;
            transparencyChange = Time.time;
        }
        if (other.gameObject.CompareTag("enemy") && Time.time >= lastHit + 2f)
        {
            hit = true;
            health -= 1;
            lastHit = Time.time;
            transparencyChange = Time.time;
        }
    }
    void Update()
    {
        if (Time.time > 3f)
        {
            if (beforeHitHealth != health)
            {
                beforeHitHealth = health;
                m_Spriterenderer.color = new Color(1f, 1f, 1f, 0.5f);
            }
            if (Time.time >= lastHit + 2f && Time.time < lastHit + 3f && Time.time > transparencyChange + 0.15f) // Switches between transparent and opaque to show the hit invulnerability ending
            {
                transparent = !transparent;

                if (transparent == true)
                {
                    m_Spriterenderer.color = new Color(1f, 1f, 1f, 0.5f);
                }
                else
                {
                    m_Spriterenderer.color = new Color(1f, 1f, 1f, 1f);
                }

                transparencyChange = Time.time;
            }
            if (Time.time >= lastHit + 3f)
            {
                hit = false;
                m_Spriterenderer.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}
