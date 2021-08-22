using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMaker : MonoBehaviour
{
    float slimeCooldown;
    public float frequency;
    public GameObject slimeBall;
    public GameObject player;
    public float burst;

    void Start()
    {
        Instantiate(slimeBall, transform.position, transform.rotation);
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (Time.time >= slimeCooldown + frequency)
        {
            slimeCooldown = Time.time;
            Instantiate(slimeBall, transform.position, transform.rotation);
        }

        if (player.GetComponent<PlayerCtrl>().isHit == true)
        {
            burst += 1;
        }
        else
        {
            burst = 0;
        }

        if (burst == 1)
        {
            Instantiate(slimeBall, transform.position, transform.rotation);
            Instantiate(slimeBall, transform.position, transform.rotation);
            Instantiate(slimeBall, transform.position, transform.rotation);
            Instantiate(slimeBall, transform.position, transform.rotation);
            Instantiate(slimeBall, transform.position, transform.rotation);
            Instantiate(slimeBall, transform.position, transform.rotation);
            Instantiate(slimeBall, transform.position, transform.rotation);
            Instantiate(slimeBall, transform.position, transform.rotation);
            Instantiate(slimeBall, transform.position, transform.rotation);
            Instantiate(slimeBall, transform.position, transform.rotation);
        }
    }
}
