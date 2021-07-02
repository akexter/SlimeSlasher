using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float health;
    float maxHealth;
    float beforeHitHealth;
    float lastHit;

    SpriteRenderer m_Spriterenderer;

    void Start()
    {
        health = 4;
        maxHealth = 4;
        beforeHitHealth = health;
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("spikes") && Time.time >= lastHit + 1f)
        {
            health -= 1;
            lastHit = Time.time;
        }
    }

    void Update()
    {
        if (beforeHitHealth != health)
        {
            beforeHitHealth = health;
            m_Spriterenderer.color = new Color(1f, 0.5f, 0.5f, 1f);
        }

        if(Time.time >= lastHit + 0.5f)
        {
            m_Spriterenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
