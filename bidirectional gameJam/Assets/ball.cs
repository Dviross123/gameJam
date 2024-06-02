using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ball : MonoBehaviour
{
    [SerializeField] GameObject ps;
    public bool inUse = false;
    public string owner = "";

    public bool hasShoot = false;

    [SerializeField] float launchSpeed = 10f;

    [SerializeField] Transform rightPos, leftPos;

    [SerializeField] Rigidbody2D rb;



    [SerializeField] GameObject endGameUI;
    [SerializeField] TextMeshProUGUI winText;

    private void Start()
    {
        rightPos = GameObject.Find("right pos").transform;
        leftPos = GameObject.Find("left pos").transform;

        endGameUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;

        winText = endGameUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (owner.Equals("left"))
        {
            //follow
            if (!hasShoot) 
            {
                rb.gravityScale = 0;
                transform.position = Vector3.Lerp(transform.position, leftPos.position, 9 * Time.deltaTime);
            }

            //shoot
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                hasShoot = true;
            }

            if (hasShoot) 
            {
                transform.position += Vector3.right * Time.deltaTime * launchSpeed;
            }
        }
        else if (owner.Equals("right"))
        {
            //follow
            if (!hasShoot)
            {
                rb.gravityScale = 0;
                transform.position = Vector3.Lerp(transform.position, rightPos.position, 9 * Time.deltaTime);
            }

            //shoot
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                hasShoot = true;
            }

            if (hasShoot)
            {
                transform.position += Vector3.left * Time.deltaTime * launchSpeed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

       

        if (collision.gameObject.CompareTag("leftP"))
        {
            winText.color = Color.blue;
            winText.text = "BLUE WON!";
            Time.timeScale = 0;
            endGameUI.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("rightP"))
        {
            winText.color = Color.red;
            winText.text = "RED WON!";
            Time.timeScale = 0;
            endGameUI.SetActive(true);
        }

       // Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
