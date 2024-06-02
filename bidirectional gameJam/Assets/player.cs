using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] bool isLeft;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] LayerMask ballLm;
    [SerializeField]GameObject psRed;
    [SerializeField]GameObject psBlue;

    void Update()
    {
        if (isLeft)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(0, speed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(0, -speed);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            if (Input.GetKey(KeyCode.E))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 100f, ballLm);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetComponent<ball>().inUse == false)
                    {
                        hit.collider.gameObject.GetComponent<ball>().inUse = true;
                        hit.collider.gameObject.GetComponent<ball>().owner = "left";
                        Instantiate(psRed,transform.GetChild(0).transform.position, Quaternion.identity);
                    }
                }
            }
           
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

            if (Input.GetKey(KeyCode.RightShift))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 100f, ballLm);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetComponent<ball>().inUse == false) 
                    {
                        hit.collider.gameObject.GetComponent<ball>().inUse = true;
                        hit.collider.gameObject.GetComponent<ball>().owner = "right";
                        Instantiate(psBlue, transform.GetChild(0).transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball")) 
        {
           
        }
    }
}
