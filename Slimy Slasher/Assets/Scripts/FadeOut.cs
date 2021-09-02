using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float alpha;
    public Color color;
    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        alpha = 1f;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = new Color(alpha, 1f, 1f, 1f);
    }

    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad >= 1.25f)
        {
            alpha -= 0.05f;
            color = new Color(1f, 1f, 1f, alpha);
            m_SpriteRenderer.color = color;
        }
    }
}
