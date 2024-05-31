using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] GameObject ps;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("leftP"))
        {
            print("right won");
        }

        else if (collision.gameObject.CompareTag("rightP"))
        {
            print("left won");
        }

        // Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
