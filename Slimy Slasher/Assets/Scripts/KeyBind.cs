using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBind : MonoBehaviour
{
    public float Key;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update() // Compares each Key object's assigned value to ensure that the key that responds is the right one
    {
        if (Input.GetKeyDown(KeyCode.W) && Key == 1)
        {
            animator.SetBool("keydown", true);
        }
        if (Input.GetKeyUp(KeyCode.W) && Key == 1)
        {
            animator.SetBool("keydown", false);
        }
        if (Input.GetKeyDown(KeyCode.A) && Key == 2)
        {
            animator.SetBool("keydown", true);
        }
        if (Input.GetKeyUp(KeyCode.A) && Key == 2)
        {
            animator.SetBool("keydown", false);
        }
        if (Input.GetKeyDown(KeyCode.S) && Key == 3)
        {
            animator.SetBool("keydown", true);
        }
        if (Input.GetKeyUp(KeyCode.S) && Key == 3)
        {
            animator.SetBool("keydown", false);
        }
        if (Input.GetKeyDown(KeyCode.D) && Key == 4)
        {
            animator.SetBool("keydown", true);
        }
        if (Input.GetKeyUp(KeyCode.D) && Key == 4)
        {
            animator.SetBool("keydown", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Key == 5)
        {
            animator.SetBool("keydown", true);
        }
        if (Input.GetKeyUp(KeyCode.Space) && Key == 5)
        {
            animator.SetBool("keydown", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && Key == 6)
        {
            animator.SetBool("keydown", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && Key == 6)
        {
            animator.SetBool("keydown", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Key == 7)
        {
            animator.SetBool("keydown", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && Key == 7)
        {
            animator.SetBool("keydown", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && Key == 8)
        {
            animator.SetBool("keydown", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && Key == 8)
        {
            animator.SetBool("keydown", false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Key == 9)
        {
            animator.SetBool("keydown", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && Key == 9)
        {
            animator.SetBool("keydown", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if(Key == 10)
            {
                animator.SetBool("keydown", true);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if(Key == 10)
            {
                animator.SetBool("keydown", false);
            }
        }
    }
}
