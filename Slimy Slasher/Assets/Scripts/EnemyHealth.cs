using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public bool hurt;

    public GameObject slimeBall;

    void OnTriggerEnter2D(Collider2D other)
    {
        hurt = true;
        if (other.gameObject.CompareTag("weapon")) // Makes a large number of slime balls upon being damaged
        {
            health -= other.gameObject.GetComponent<Slash>().damage;
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

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("weapon"))
        {
            hurt = false;
        }
    }
}
