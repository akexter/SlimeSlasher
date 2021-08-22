using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float currentHealth;

    void Update()
    {
        transform.position = new Vector3(GameObject.Find("Player").transform.position.x - 11, GameObject.Find("Player").transform.position.y + 6, transform.position.z);
        currentHealth = GameObject.Find("Player").GetComponent<PlayerHealth>().health;
    }
}
