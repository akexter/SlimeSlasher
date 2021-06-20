using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisappear : MonoBehaviour
{
    public bool isTriggered;
    float alpha;
    public Color color;
    SpriteRenderer m_SpriteRenderer;
    void Start()
    {
        alpha = 1f;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (isTriggered == true)
        {
            alpha -= 0.04f;
            color = new Color(1f, 1f, 1f, alpha);
            m_SpriteRenderer.color = color;
            if (alpha <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}