using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public void GoToLevel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level02");
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        GameManager.RestartLevel();
    }
}
