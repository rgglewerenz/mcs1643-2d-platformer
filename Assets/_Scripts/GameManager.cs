using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;

    public static bool _paused;

    public static bool _gameOver = false;

    public static int lives = 3;

    public static int Score = 0;

    public static void SubtractLife()
    {
        lives -= 1;
        if (lives <= 0)
        {
            _gameOver = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        _paused = false;
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
}
