using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Character, GameMan;

    public GameManager GameManager;

    public Rigidbody2D rb, rb2;

    public float speed;

    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        GameMan = GameObject.Find("Game Manager");
        GameManager = GameMan.GetComponent<GameManager>();
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        rb2 = Character.GetComponent<Rigidbody2D>();
        speed = 100f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canMove)
        {
            if(Input.GetKey(KeyCode.W))
            {
                /*transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z * 0);
                //transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
                rb.AddForce(transform.up * speed);*/
                rb.velocity = new Vector2(0, 50);
                rb2.velocity = new Vector2(0, -50);
                canMove = false;
            }

            else if(Input.GetKey(KeyCode.A))
            {
                /*transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (transform.eulerAngles.z * 0) +90);
            // transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
                rb.AddForce(transform.up * speed);*/
                rb.velocity = new Vector2(-50, 0);
                rb2.velocity = new Vector2(50, 0);
                canMove = false;
            }

            else if(Input.GetKey(KeyCode.S))
            {
                /*transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (transform.eulerAngles.z * 0) +180);
                //transform.Rotate(0.0f, 0.0f, -180.0f, Space.Self);
                rb.AddForce(transform.up * speed);*/
                rb.velocity = new Vector2(0, -50);
                rb2.velocity = new Vector2(0, 50);
                canMove = false;
                
            }

            else if(Input.GetKey(KeyCode.D))
            {
                /*transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (transform.eulerAngles.z * 0) -90);
                //transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
                rb.AddForce(transform.up * speed);*/
                rb.velocity = new Vector2(50, 0);
                rb2.velocity = new Vector2(-50, 0);
                canMove = false;
            }
        }
        
    }

    public void OnCollisionEnter2D(Collision2D wall)
    {
        if(wall.gameObject.name == "Wall")
        {
            //rb.velocity = new Vector2(0, 0);
            //rb2.velocity = new Vector2(0, 0);
            canMove = true;
        }
    }

    public void OnCollisionStay2D(Collision2D wall)
    {
        if(wall.gameObject.name == "Wall")
        {
            //rb.velocity = new Vector2(0, 0);
            //rb2.velocity = new Vector2(0, 0);
            canMove = true;
        }
    }


    public void OnTriggerEnter2D(Collider2D fork)
    {
        if(fork.tag == "Fork")
        {
            transform.position = new Vector2(fork.gameObject.transform.position.x, fork.gameObject.transform.position.y);
            rb.velocity = new Vector2(0, 0);
            rb2.velocity = new Vector2(0, 0);
            canMove = true;
        }

        if(fork.tag == "Coin")
        {
            GameManager.location = Random.Range(0,19);
            GameManager.coinCount ++;

            GameManager.coinLo = new Vector3(GameManager.coinP[GameManager.location].transform.position.x, GameManager.coinP[GameManager.location].transform.position.y, GameManager.coinP[GameManager.location].transform.position.z);

            GameManager.coin.transform.position = GameManager.coinLo;

            
        }

        
    }
}
