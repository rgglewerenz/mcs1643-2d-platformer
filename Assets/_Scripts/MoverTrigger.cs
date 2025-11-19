using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTrigger : MonoBehaviour
{
    public bool DefaultState = false;
    public Mover Mover;

    private void Start()
    {
        if (Mover != null)
        {
            Mover.Moving = DefaultState;
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Player")
        {
            return;
        }

        if (Mover != null)
        {
            Mover.Moving = !DefaultState;
        }
    }
}
