using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;

    public GameObject GameOverMenu;

    public GameObject PlayerUI;

    public TMPro.TextMeshProUGUI ScoreText;

    public TMPro.TextMeshProUGUI LivesText;

    public static bool _paused;

    public static bool _gameOver = false;

    protected static int lives;

    protected static int StartingLives = 5;

    protected static int Score = 0;

    public static void RestartLevel()
    {
        lives = StartingLives;
        Score = 0;
        _gameOver = false;
        _paused = false;
    }

    public static void SubtractLife()
    {
        lives -= 1;
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.UpdateUI();
        if (lives <= 0)
        {
            _gameOver = true;
            var GameOverMenu = gameManager.GameOverMenu;
            GameOverMenu.SetActive(true);
            var PlayerUI = gameManager.PlayerUI;
            PlayerUI.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public static void AddLife()
    {
        lives += 1;
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.UpdateUI();
    }

    public static void AddScore(int amount)
    {
        Score += amount;
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.UpdateUI();
    }

    public static int GetScore()
    {
        return Score;
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = StartingLives;
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        PlayerUI.SetActive(true);
        _paused = false;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_paused)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                _paused = true;
            }
            else
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
                _paused = false;
            }
        }
    }

    public void UpdateUI()
    {
        ScoreText.text = "Score: " + Score.ToString();
        LivesText.text = "Lives: " + lives.ToString();
    }
}
