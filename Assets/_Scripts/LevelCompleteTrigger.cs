using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    public Sprite CompletedSprite;
    public GameObject LevelCompletedMenu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.tag);

        if (other.tag != "Player")
        {
            return;
        }

        GetComponent<SpriteRenderer>().sprite = CompletedSprite;

        //play sound

        LevelCompletedMenu.SetActive(true);

        Time.timeScale = 0;
    }



}
