using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public bool Moving = false;
    public float MinDistance = 0.01f;
    public float speed = 1.2f;


    private bool MovingToPointA = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._gameOver || GameManager._paused) return;
        if (!Moving)
        {
            return;
        }

        CheckDirection();
        MoveEntity();

    }

    private void MoveEntity()
    {
        if (MovingToPointA)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, PointA.position, speed * Time.deltaTime);
            return;
        }

        this.transform.position = Vector2.MoveTowards(this.transform.position, PointB.position, speed * Time.deltaTime);
    }

    private void CheckDirection()
    {
        if (MovingToPointA)
        {
            if (Vector2.Distance(transform.position, PointA.position) <= MinDistance)
            {
                MovingToPointA = !MovingToPointA;
            }

            return;
        }

        if (Vector2.Distance(transform.position, PointB.position) <= MinDistance)
        {
            MovingToPointA = !MovingToPointA;
        }
    }
}
