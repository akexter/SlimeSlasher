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
        if (other.gameObject.CompareTag("spikes") && Time.timeSinceLevelLoad >= lastHit + 2f) // Prevents the player from instantly dying from spikes
        {
            hit = true;
            health -= 1;
            lastHit = Time.timeSinceLevelLoad;
            transparencyChange = Time.timeSinceLevelLoad;
        }
        if (other.gameObject.CompareTag("enemy") && Time.timeSinceLevelLoad >= lastHit + 2f) // Prevents the player from instantly dying from an enemy
        {
            hit = true;
            health -= 1;
            lastHit = Time.timeSinceLevelLoad;
            transparencyChange = Time.timeSinceLevelLoad;
        }
    }
    void Update()
    {
        if (Time.timeSinceLevelLoad > 3f) // Controls how the player's health behaves
        {
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            if (beforeHitHealth != health)
            {
                beforeHitHealth = health;
                m_Spriterenderer.color = new Color(1f, 1f, 1f, 0.5f);
            }
            if (Time.timeSinceLevelLoad >= lastHit + 1f && Time.timeSinceLevelLoad < lastHit + 2f && Time.timeSinceLevelLoad > transparencyChange + 0.15f) // Switches between transparent and opaque to show the hit invulnerability ending
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

                transparencyChange = Time.timeSinceLevelLoad;
            }
            if (Time.timeSinceLevelLoad >= lastHit + 2f)
            {
                hit = false;
                m_Spriterenderer.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}
