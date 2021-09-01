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
        if (Time.time >= slimeCooldown + frequency + Random.Range(-frequency/2, frequency/2))
        {
            slimeCooldown = Time.time;
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
        }

        if (player.GetComponent<PlayerCtrl>().isHit == true && GameObject.Equals(gameObject, player))
        {
            burst += 1;
        }
        else
        {
            burst = 0;
        }

        if (burst == 1)
        {
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
            Instantiate(slimeBall, new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f)), transform.rotation);
        }
    }
}
