using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] bool isLeft;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] LayerMask ballLm;

    [SerializeField] AudioSource src;
    [SerializeField] AudioClip catchSfx;

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
                        src.PlayOneShot(catchSfx);
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
                        src.PlayOneShot(catchSfx);
                    }
                }
            }
        }
    }

}
