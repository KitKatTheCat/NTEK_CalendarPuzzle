using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUIHolder;
    [SerializeField] private GameObject OptionsUIHolder;
    [SerializeField] private GameObject TitleUIHolder;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptions()
    {
        TitleUIHolder.SetActive(false);
        MainMenuUIHolder.SetActive(false);
        OptionsUIHolder.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
