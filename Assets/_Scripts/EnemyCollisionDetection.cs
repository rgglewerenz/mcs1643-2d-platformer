using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    public Transform parentEnemy;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            playerMovement.Jump();

            Destroy(parentEnemy.gameObject);

            GameManager.AddScore(100);
        }
    }
}
