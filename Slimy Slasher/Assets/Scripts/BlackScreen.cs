using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    public GameObject player;
    public float alpha;
    public Color color;
    SpriteRenderer m_SpriteRenderer;
    void Start()
    {
        alpha = 1f;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        m_SpriteRenderer.color = new Color(alpha, 1f, 1f, 1f);
    }

    void FixedUpdate()
    {
        if (player.GetComponent<PlayerCtrl>().isHit == true && alpha <= 1 && Time.timeSinceLevelLoad >= player.GetComponent<PlayerCtrl>().lastHit + 0.5f)
        {
            alpha += 0.1f;
            color = new Color(1f, 1f, 1f, alpha);
            m_SpriteRenderer.color = color;
        }
        if (player.GetComponent<PlayerCtrl>().isHit == false && alpha >= 0 && Time.timeSinceLevelLoad >= player.GetComponent<PlayerCtrl>().lastHit + 1.25f)
        {
            alpha -= 0.05f;
            color = new Color(1f, 1f, 1f, alpha);
            m_SpriteRenderer.color = color;
        }
    }
}