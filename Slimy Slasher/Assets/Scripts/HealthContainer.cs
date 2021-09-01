using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : MonoBehaviour
{
    GameObject Player;
    public Animator animator;
    public float healthNumber;

    void Start()
    {
        Player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        healthNumber = GetComponentInParent<HealthPip>().healthNumber;
    }

    void Update()
    {
        if (healthNumber == 1 && healthNumber == Player.GetComponent<PlayerHealth>().maxHealth) // Chooses what sprite each individual container should take
        {
            animator.SetBool("container1", true);
            animator.SetBool("container2", false);
            animator.SetBool("container3", false);
            animator.SetBool("container4", false);
        }
        if (healthNumber == 1 && healthNumber < Player.GetComponent<PlayerHealth>().maxHealth)
        {
            animator.SetBool("container1", false);
            animator.SetBool("container2", true);
            animator.SetBool("container3", false);
            animator.SetBool("container4", false);
        }
        if (healthNumber > 1 && healthNumber < Player.GetComponent<PlayerHealth>().maxHealth)
        {
            animator.SetBool("container1", false);
            animator.SetBool("container2", false);
            animator.SetBool("container3", true);
            animator.SetBool("container4", false);
        }
        if (healthNumber > 1 && healthNumber == Player.GetComponent<PlayerHealth>().maxHealth)
        {
            animator.SetBool("container1", false);
            animator.SetBool("container2", false);
            animator.SetBool("container3", false);
            animator.SetBool("container4", true);
        }
        if (healthNumber <= Player.GetComponent<PlayerHealth>().maxHealth) // Makes the container disppear when its healthNumber is greater than the maximum health
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
