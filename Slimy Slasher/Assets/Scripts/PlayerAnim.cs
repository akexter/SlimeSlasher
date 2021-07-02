using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    Rigidbody2D rb;
    public Animator animator;
    public float angle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (rb.velocity.x <= 0)
        {
            m_SpriteRenderer.flipX = true;
            animator.SetBool("idle", false);
        }
        if (rb.velocity.x >= 0)
        {
            m_SpriteRenderer.flipX = false;
            animator.SetBool("idle", false);
        }
        if (rb.velocity.x == 0)
        {
            animator.SetBool("idle", true);
        }
        if (rb.velocity.y <= -5)
        {
            animator.SetBool("falling", true);
            animator.SetBool("jumping", false);
        }
        if (rb.velocity.y >= 5)
        {
            animator.SetBool("jumping", true);
            animator.SetBool("falling", false);
        }
        if (rb.velocity.y < 5 && rb.velocity.y > -5)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
        }
        if (GetComponent<PlayerCtrl>().canDash == false && GetComponent<PlayerCtrl>().fixedVelocity == true)
        {
            animator.SetBool("dash", true);
        }
        if (GetComponent<PlayerCtrl>().canDash == false && GetComponent<PlayerCtrl>().fixedVelocity == false)
        {
            animator.SetBool("dash", false);
        }
        if (GetComponent<Weapon>().canAttack == false && GetComponent<Weapon>().weaponUnlocked == true)
        {
            animator.SetBool("attacking", true);
        }
        /* if (GetComponent<Weapon>().canAttack == false && GetComponent<Weapon>().weaponUnlocked == true)
        {
            animator.SetBool("attacking", true);

            if (angle >= 67.5 && angle <= 112.5)
            {
                animator.SetBool("up", true);
            }
            if (angle <= -67.5 && angle >= -112.5)
            {
                animator.SetBool("down", true);
            }
        }
        if (GetComponent<Weapon>().canAttack == true)
        {
            animator.SetBool("attacking", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        } */
    }
}
