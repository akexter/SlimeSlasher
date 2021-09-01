using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPip : MonoBehaviour
{
    GameObject Player;
    public Animator animator;

    public float healthNumber;

    void Start()
    {
        Player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (healthNumber == 1 && healthNumber == Player.GetComponent<PlayerHealth>().maxHealth) // Chooses what sprite each individual pip should take
        {
            animator.SetBool("pip1", true);
            animator.SetBool("pip2", false);
            animator.SetBool("pip3", false);
            animator.SetBool("pip4", false);
        }
        if (healthNumber == 1 && healthNumber < Player.GetComponent<PlayerHealth>().maxHealth)
        {
            animator.SetBool("pip1", false);
            animator.SetBool("pip2", true);
            animator.SetBool("pip3", false);
            animator.SetBool("pip4", false);
        }
        if (healthNumber > 1 && healthNumber < Player.GetComponent<PlayerHealth>().maxHealth)
        {
            animator.SetBool("pip1", false);
            animator.SetBool("pip2", false);
            animator.SetBool("pip3", true);
            animator.SetBool("pip4", false);
        }
        if (healthNumber > 1 && healthNumber == Player.GetComponent<PlayerHealth>().maxHealth)
        {
            animator.SetBool("pip1", false);
            animator.SetBool("pip2", false);
            animator.SetBool("pip3", false);
            animator.SetBool("pip4", true);
        }
        if (healthNumber <= Player.GetComponent<PlayerHealth>().health) // Makes the pip disappear when the player's health is less than the pip's number
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        if (healthNumber > Player.GetComponent<PlayerHealth>().maxHealth) // Makes the pip disppear when its healthNumber is greater than the maximum health
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
