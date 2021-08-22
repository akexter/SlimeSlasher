using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretFade : MonoBehaviour
{
    float alpha;
    public GameObject player;
    void Start()
    {
        alpha = 1f;
        gameObject.GetComponent<Tilemap>().color = new Color(1f, 1f, 1f, alpha);
        player = GameObject.Find("Player");
    }
    void FixedUpdate()
    {
        if (GetComponentInChildren<SecretActivator>().isTriggered == true && alpha >= 0)
        {
            alpha -= 0.01f;
            gameObject.GetComponent<Tilemap>().color = new Color(1f, 1f, 1f, alpha);
        }

        if (player.GetComponent<PlayerHealth>().health <= 0)
        {
            alpha = 1f;
            GetComponentInChildren<SecretActivator>().isTriggered = false;
        }
    }
}
