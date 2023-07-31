using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject TimerUI;
    public GameObject BoardHolder;
    public GameObject TrayHolder;
    public GameObject SelectionHolder;

    public GameObject InstructionsHolder;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    private void Start()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void PlayGame()
    {
        InstructionsHolder.SetActive(false);
        TimerUI.SetActive(true);
        BoardHolder.SetActive(true);
        TrayHolder.SetActive(true);
        SelectionHolder.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    public void QuitGame()
    {
        Debug.Log("Qutting game");
        Application.Quit();
    }

}
