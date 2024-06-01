using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }

    void restart() 
    {
        SceneManager.LoadScene(1);
    }
}
