using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject playButton;
    public GameObject exitButton;
    public GameObject gameOver;
    private int score;
    private int highscore;
    public Text scoreText;
    public Text highscoreText;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        string sceneName = SceneManager.GetActiveScene().name; // Get the current scene name
        highscore = PlayerPrefs.GetInt(sceneName + "High Score"); // Use the scene name to get the appropriate high score
        gameOver.SetActive(false);
        Pause();
    }

    public void Play()
    {
         score = 0;
         scoreText.text = score.ToString();
         highscoreText.text = highscore.ToString();
         gameOver.SetActive(false);
         playButton.SetActive(false);
         exitButton.SetActive(false);

         Time.timeScale = 1f;
         player.enabled = true;

         Pipes[] pipes = FindObjectsOfType<Pipes>();

         for(int i = 0; i < pipes.Length; i++){
            Destroy(pipes[i].gameObject);
        }
    }

    
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        exitButton.SetActive(true);

        if(score > highscore)
        {
            string sceneName = SceneManager.GetActiveScene().name; // Get the current scene name
            PlayerPrefs.SetInt(sceneName + "High Score", score); // Use the scene name to set the appropriate high score
            PlayerPrefs.Save();

            if(sceneName == "Quiz")
            {
                PlayerPrefs.SetInt("QuizHighScore", score);

            }

            else if(sceneName == "Mid")
            {
                PlayerPrefs.SetInt("MidHighScore", score);
            }

            else if(sceneName == "Final")
            {
                PlayerPrefs.SetInt("FinalHighScore", score);
            }
            highscore = score;
        }
        
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    
    public void PauseGame()
    {
        Time.timeScale = 0f; // Stop time in the game
        player.enabled = false; // Disable player controls
    }

    // Add this function to resume the game after a delay of 3 seconds
    public IEnumerator ResumeGame()
    {
        yield return new WaitForSecondsRealtime(3f); // Wait for 3 seconds in real time
        Time.timeScale = 1f; // Resume time in the game
        player.enabled = true; // Enable player controls
    }

    public void StartResumeGame()
{
    StartCoroutine(ResumeGame());
}
}