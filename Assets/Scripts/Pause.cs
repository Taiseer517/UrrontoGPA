using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    public Button pauseButton;
    public Button resumeButton;

    void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        resumeButton.interactable = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        StartCoroutine(ResumeDelay());
    }

    IEnumerator ResumeDelay()
    {
        yield return new WaitForSecondsRealtime(3);
        resumeButton.interactable = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        resumeButton.interactable = false;
    }
}
