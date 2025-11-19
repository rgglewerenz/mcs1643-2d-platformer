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

    protected static int lives = 5;

    protected static int Score = 0;

    public static void SubtractLife()
    {
        lives -= 1;
        if (lives <= 0)
        {
            _gameOver = true;
            GameObject gameManager = GameObject.Find("GameManager");
            var GameOverMenu = gameManager.GetComponent<GameManager>().GameOverMenu;
            GameOverMenu.SetActive(true);
            var PlayerUI = gameManager.GetComponent<GameManager>().PlayerUI;
            PlayerUI.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public static void AddLife()
    {
        lives += 1;
    }

    public static void AddScore(int amount)
    {
        Score += amount;
    }

    public static int GetScore()
    {
        return Score;
    }

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        PlayerUI.SetActive(true);
        _paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();

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

    private void UpdateUI()
    {
        ScoreText.text = "Score: " + Score.ToString();
        LivesText.text = "Lives: " + lives.ToString();
    }
}
