using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pControl : MonoBehaviour
{
    public GameObject GameMan;

    public GameManager GameManager;

    public Player2Controller  Player2Controller;

    public Rigidbody2D rb;

    public PlayerController  PlayerController;

    //Raycasts
    public float castDist;

    

    // Start is called before the first frame update
    void Start()
    {
        GameMan = GameObject.Find("Game Manager");
        GameManager = GameMan.GetComponent<GameManager>();
        Player2Controller = GameObject.Find("Character3").GetComponent<Player2Controller>();
        PlayerController = GameObject.Find("Character1").GetComponent<PlayerController>();
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 center = gameObject.transform.position;
        RaycastHit2D right = Physics2D.Raycast(center, Vector2.right, castDist);
        RaycastHit2D left = Physics2D.Raycast(center, -Vector2.right, castDist);
        RaycastHit2D up = Physics2D.Raycast(center, Vector2.up, castDist);
        RaycastHit2D down = Physics2D.Raycast(center, -Vector2.up, castDist);

        

        if(right.collider != null)
        {
            

            if(right.transform.name != "Wall")
            {
                if(right.transform.GetComponent<rPaths>().closed)
                {
                    PlayerController.left = false;
                }
                else
                {
                    PlayerController.left = true;
                }
            }
            else
            {
                PlayerController.left = false;
            }
            
        }
        else
        {
            PlayerController.left = true;
        }

        if(left.collider != null)
        {
            

            if(left.transform.name != "Wall")
            {
                if(left.transform.GetComponent<rPaths>().closed)
                {
                    PlayerController.right = false;
                }
                else
                {
                    PlayerController.right = true;
                }
            }
            else
            {
                PlayerController.right = false;
            }
            
        }
        else
        {
            PlayerController.right = true;
        }








        if(up.collider != null)
        {
            
            if(up.transform.name != "Wall")
            {
                if(up.transform.GetComponent<rPaths>().closed)
                {
                    PlayerController.down = false;
                }
                else
                {
                    PlayerController.down = true;
                }
            }
            else
            {
                PlayerController.down = false;
            }
            
        }
        else
        {
            PlayerController.down = true;
        }








        if(down.collider != null)
        {
            
            if(down.transform.name != "Wall")
            {
                if(down.transform.GetComponent<rPaths>().closed)
                {
                    PlayerController.up = false;
                }
                else
                {
                    PlayerController.up = true;
                }
            }
            else
            {
                PlayerController.up = false;
            }
            
        }
        else
        {
            PlayerController.up = true;
        }

        

        /*Debug.DrawRay(center, Vector2.right * right.distance, Color.red);

        Debug.DrawRay(center, -Vector2.right * left.distance, Color.red);

        Debug.DrawRay(center, Vector2.up * up.distance, Color.red);

        Debug.DrawRay(center, -Vector2.up * down.distance, Color.red);*/

        /*Debug.DrawRay(center, transform.right * -(left.distance), Color.red);

        Debug.DrawRay(center, transform.up * up.distance, Color.red);

        Debug.DrawRay(center, transform.forward * -(down.distance), Color.red);*/


    }

    public void OnTriggerEnter2D(Collider2D fork)
    {
        if(fork.tag == "Fork")
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = new Vector2(fork.gameObject.transform.position.x, fork.gameObject.transform.position.y); 
            
        }

        if(fork.tag == "Coin")
        {
            GameManager.location1 = Random.Range(0,65);
            GameManager.coinCount1 ++;

            GameManager.coinLo1 = new Vector3(GameManager.coinP1[GameManager.location1].transform.position.x, GameManager.coinP1[GameManager.location1].transform.position.y, GameManager.coinP1[GameManager.location1].transform.position.z);

            GameManager.coin1.transform.position = GameManager.coinLo1;

            
        }

        if(fork.tag == "Clock")
        {
            StartCoroutine(Player2Controller.clock());
            Destroy(fork.gameObject);
        }

        if(fork.tag == "Arrows")
        {
            StartCoroutine(Player2Controller.arrows());
            Destroy(fork.gameObject);
        }

        if(fork.tag == "badCoin")
        {
            GameManager.coinCount2--;
            Destroy(fork.gameObject);
            
        }
    }
}
