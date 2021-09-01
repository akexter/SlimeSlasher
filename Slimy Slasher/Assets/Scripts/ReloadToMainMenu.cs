using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadToMainMenu : MonoBehaviour
{
    void Update()
    {
        if(Time.timeSinceLevelLoad >= 10f)
        {
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
    }
}
