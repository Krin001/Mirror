using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p4Control : MonoBehaviour
{
   public GameObject GameMan;

    public GameManager GameManager;

    public Rigidbody2D rb;

    public PlayerController  PlayerController;

    public Player2Controller  Player2Controller;

    //Raycasts
    public float castDist;


    

    // Start is called before the first frame update
    void Start()
    {
        GameMan = GameObject.Find("Game Manager");
        GameManager = GameMan.GetComponent<GameManager>();
        PlayerController = GameObject.Find("Character1").GetComponent<PlayerController>();
        Player2Controller = GameObject.Find("Character3").GetComponent<Player2Controller>();
        
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
                    Player2Controller.left = false;
                }
                else
                {
                    Player2Controller.left = true;
                }
            }
            else
            {
                Player2Controller.left = false;
            }
            
        }
        else
        {
            Player2Controller.left = true;
        }

        if(left.collider != null)
        {
            Debug.Log(left.transform.name);

            if(left.transform.name != "Wall")
            {
                if(left.transform.GetComponent<rPaths>().closed)
                {
                    Player2Controller.right = false;
                }
                else
                {
                    Player2Controller.right = true;
                }
            }
            else
            {
                Player2Controller.right = false;
            }
            
        }
        else
        {
            Player2Controller.right = true;
        }








        if(up.collider != null)
        {
            Debug.Log(up.transform.name);
            if(up.transform.name != "Wall")
            {
                if(up.transform.GetComponent<rPaths>().closed)
                {
                    Player2Controller.down = false;
                }
                else
                {
                    Player2Controller.down = true;
                }
            }
            else
            {
                Player2Controller.down = false;
            }
            
        }
        else
        {
            Player2Controller.down = true;
        }








        if(down.collider != null)
        {
            Debug.Log(down.transform.name);
            if(down.transform.name != "Wall")
            {
                if(down.transform.GetComponent<rPaths>().closed)
                {
                    Player2Controller.up = false;
                }
                else
                {
                    Player2Controller.up = true;
                }
            }
            else
            {
                Player2Controller.up = false;
            }
            
        }
        else
        {
            Player2Controller.up = true;
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
            GameManager.location2 = Random.Range(0,65);
            GameManager.coinCount2 ++;

            GameManager.coinLo2 = new Vector3(GameManager.coinP2[GameManager.location2].transform.position.x, GameManager.coinP2[GameManager.location2].transform.position.y, GameManager.coinP2[GameManager.location2].transform.position.z);

            GameManager.coin2.transform.position = GameManager.coinLo2;

            
        }

        if(fork.tag == "Clock")
        {
            StartCoroutine(PlayerController.clock());
            Destroy(fork.gameObject);
        }

        if(fork.tag == "Arrows")
        {
            StartCoroutine(PlayerController.arrows());
            Destroy(fork.gameObject);
        }
    }
}
