using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] bool isLeft;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    void Update()
    {
        if (isLeft) 
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(0, speed );
            }

            else if (Input.GetKey(KeyCode.S)) 
            {
                rb.velocity = new Vector2(0, -speed);
            }

            else
                rb.velocity =Vector2.zero;

            
        }

        else 
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(0, speed);
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(0, -speed);
            }

            else
                rb.velocity = Vector2.zero;
        }
    }
}
