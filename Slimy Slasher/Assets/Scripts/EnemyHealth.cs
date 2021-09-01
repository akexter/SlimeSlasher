using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    public GameObject slimeBall;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("weapon"))
        {
            health -= other.gameObject.GetComponent<Slash>().damage;
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

            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
