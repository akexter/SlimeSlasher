using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    public GameObject slimeBall;

    private void OnCollisionEnter2D(Collision2D other)
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
        }
    }
}
