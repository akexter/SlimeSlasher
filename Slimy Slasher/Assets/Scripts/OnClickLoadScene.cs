using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClickLoadScene : MonoBehaviour
{
    public Button leftClick;
    public float clickTime;

    void Start()
    {
        leftClick.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        clickTime = Time.time;
    }
    void Update()
    {
        if (Time.time >= clickTime + 1f && clickTime != 0)
        {
            SceneManager.LoadScene("Main Game", LoadSceneMode.Single);
        }
    }
}
