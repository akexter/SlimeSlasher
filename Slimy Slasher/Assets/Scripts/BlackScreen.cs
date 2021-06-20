using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    public GameObject player;
    float alpha;
    public Color color;
    SpriteRenderer m_SpriteRenderer;
    void Start()
    {
        alpha = 0f;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (player.GetComponent<PlayerCtrl>().isHit == true && alpha <= 1)
        {
            alpha += 0.10f;
            color = new Color(1f, 1f, 1f, alpha);
            m_SpriteRenderer.color = color;
        }
        if (player.GetComponent<PlayerCtrl>().isHit == false && alpha >= 0)
        {
            alpha -= 0.05f;
            color = new Color(1f, 1f, 1f, alpha);
            m_SpriteRenderer.color = color;
        }
    }
}