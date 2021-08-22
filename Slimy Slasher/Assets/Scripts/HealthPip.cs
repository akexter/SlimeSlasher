using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPip : MonoBehaviour
{
    GameObject Player;

    public float healthNumber;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (healthNumber <= Player.GetComponent<PlayerHealth>().health) // Makes the pip disappear when the player's health
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
