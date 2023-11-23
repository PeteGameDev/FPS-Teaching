using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Screen : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject pauseScreenUI;

    void Start()
    {
        Time.timeScale = 1f;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            GamePause();
        }
    }

    public void GamePause(){
        Time.timeScale = 0f;
        inGameUI.SetActive(false);
        pauseScreenUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void GameResume(){
        Time.timeScale = 1f;
        inGameUI.SetActive(true);
        pauseScreenUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
