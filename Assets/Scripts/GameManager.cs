using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;

    private void Awake()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            return;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);   
    }

    public void Exit()
    {
        Application.Quit();
    }

}