using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMaker : MonoBehaviour
{
    float slimeCooldown;
    public GameObject slimeBall;

    void Start()
    {
        Instantiate(slimeBall, transform.position, transform.rotation);
    }
    void Update()
    {
        if (Time.time >= slimeCooldown + 0.5f)
        {
            slimeCooldown = Time.time;
            Instantiate(slimeBall, transform.position, transform.rotation);
        }
    }
}
