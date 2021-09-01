using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashChecker : MonoBehaviour
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

    void Update()
    {
        if (player.GetComponent<PlayerCtrl>().canDash == true && player.GetComponent<PlayerCtrl>().dashUnlocked == true)
        {
            alpha = 1f;
            color = new Color(1f, 1f, 1f, alpha);
            m_SpriteRenderer.color = color;
        }
        else
        {
            alpha = 0f;
            color = new Color(1f, 1f, 1f, alpha);
            m_SpriteRenderer.color = color;
        }
    }
}
