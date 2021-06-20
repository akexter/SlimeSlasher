using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretActivator : MonoBehaviour
{
    public bool isTriggered;
    void Start()
    {
        gameObject.GetComponent<Tilemap>().color = new Color(1f, 1f, 1f, 1f);
    }
    void Update()
    {
        if (isTriggered == true)
        {
            gameObject.GetComponent<Tilemap>().color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
