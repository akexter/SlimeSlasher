using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseButton : MonoBehaviour
{
    public Button leftClick;
    public float clickTime;
    Animator animator;

    void Start()
    {
        leftClick.onClick.AddListener(TaskOnClick);
        animator = GetComponent<Animator>();
    }
    void TaskOnClick()
    {
        animator.SetBool("hover", true);
    }
}
