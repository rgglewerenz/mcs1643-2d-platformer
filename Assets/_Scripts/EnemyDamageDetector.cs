using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDetector : MonoBehaviour
{
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 bumpDirection = (collision.transform.position - transform.position).normalized;
            bumpDirection.y = 0.5f; // Add some upward force
            bumpDirection.Normalize();

            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            if (playerRb != null)
            {
                playerRb.AddForce(bumpDirection * playerMovement.enemyBumpForce, ForceMode2D.Impulse);
            }
            GameManager.SubtractLife();
        }
    }
}
