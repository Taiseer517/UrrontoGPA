using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    private AudioSource ChooseMusic;
    public Text quizHighScoreText;
    public Text midHighScoreText;
    public Text finalHighScoreText;

    void Start()
    {
        quizHighScoreText.text = PlayerPrefs.GetInt("QuizHighScore", 0).ToString();
        midHighScoreText.text = PlayerPrefs.GetInt("MidHighScore", 0).ToString();
        finalHighScoreText.text = PlayerPrefs.GetInt("FinalHighScore", 0).ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void quizScene()
    {
        SceneManager.LoadScene(1);
    }

    public void midScene()
    {
        SceneManager.LoadScene(2);
    }

    public void finalScene()
    {
        SceneManager.LoadScene(3);
    }

    public void Exit()
    {
        Application.Quit();
    }
}