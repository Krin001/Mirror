
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Character, GameMan;

    public GameManager GameManager;

    public Player2Controller  Player2Controller;

    public Rigidbody2D rb, rb2;

    public float speed;

    public bool canMove,freeze;

    public GameObject[] permPath = new GameObject[33];

    public bool up, up1, down, down1, left, left1, right, right1;

    //Raycasts
    public float castDist;

   

    // Start is called before the first frame update
    void Start()
    {
        GameMan = GameObject.Find("Game Manager");
        GameManager = GameMan.GetComponent<GameManager>();
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        rb2 = Character.GetComponent<Rigidbody2D>();
        speed = 20f;

        Player2Controller = GameObject.Find("Character3").GetComponent<Player2Controller>();

        for(int i = 0; i < 33; i++)
        {
            permPath[i] = GameObject.Find("permanentPath (" +(i) +")");
        }

       


        
    }

    void Update()
    {
        /*if((!up1&&!left1&&!down1&&!right1)||(!up&&!left&&!down&&!right))
        {
            GameManager.ranPaths1();
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        //= Vector3.Distance(transform.position, col.transform.position);
        if(!freeze)
        {
            if(canMove)
            {
                GameManager.pauseTime1 = false;

                if(up&&up1)
                {
                    if(Input.GetKey(KeyCode.UpArrow))
                    {
                       
                        rb.velocity = new Vector2(0, speed);
                        rb2.velocity = new Vector2(0, -speed);
                        canMove = false;
                        
                    }
                }
                
                if(left&&left1)
                {
                    if(Input.GetKey(KeyCode.LeftArrow))
                    {
                        
                        rb.velocity = new Vector2(-speed, 0);
                        rb2.velocity = new Vector2(speed, 0);
                        canMove = false;
                        
                    }
                }

                if(down&&down1)
                {
                    if(Input.GetKey(KeyCode.DownArrow))
                    {
                        
                        rb.velocity = new Vector2(0, -speed);
                        rb2.velocity = new Vector2(0, speed);
                        canMove = false;
                        
                        
                    }
                }

                if(right&&right1)
                {
                    if(Input.GetKey(KeyCode.RightArrow))
                    {
                        
                        rb.velocity = new Vector2(speed, 0);
                        rb2.velocity = new Vector2(-speed, 0);
                        canMove = false;
                        
                    }
                }
            }
            else
            {
                GameManager.pauseTime1 = true;
            }
        }

        //raycasts

        Vector2 center = gameObject.transform.position;
        RaycastHit2D rayright = Physics2D.Raycast(center, Vector2.right, castDist);
        RaycastHit2D rayleft = Physics2D.Raycast(center, -Vector2.right, castDist);
        RaycastHit2D rayup = Physics2D.Raycast(center, Vector2.up, castDist);
        RaycastHit2D raydown = Physics2D.Raycast(center, -Vector2.up, castDist);

        

        if(rayright.collider != null)
        {
            

            if(rayright.transform.name != "Wall")
            {
                if(rayright.transform.GetComponent<rPaths>().closed)
                {
                    right1 = false;
                }
                else
                {
                    right1 = true;
                }
            }
            else
            {
                right1 = false;
            }
            
        }
        else
        {
            right1 = true;
        }


        if(rayleft.collider != null)
        {
            Debug.Log(rayleft.transform.name);

            if(rayleft.transform.name != "Wall")
            {
                if(rayleft.transform.GetComponent<rPaths>().closed)
                {
                    left1 = false;
                }
                else
                {
                    left1 = true;
                }
            }
            else
            {
                left1 = false;
            }
            
        }
        else
        {
            left1 = true;
        }


        if(rayup.collider != null)
        {
            Debug.Log(rayup.transform.name);
            if(rayup.transform.name != "Wall")
            {
                if(rayup.transform.GetComponent<rPaths>().closed)
                {
                    up1 = false;
                }
                else
                {
                    up1 = true;
                }
            }
            else
            {
                up1 = false;
            }
            
        }
        else
        {
            up1 = true;
        }


        if(raydown.collider != null)
        {
            Debug.Log(raydown.transform.name);
            if(raydown.transform.name != "Wall")
            {
                if(raydown.transform.GetComponent<rPaths>().closed)
                {
                    down1 = false;
                }
                else
                {
                    down1 = true;
                }
            }
            else
            {
                down1 = false;
            }
            
        }
        else
        {
            down1 = true;
        }

        

        Debug.DrawRay(center, Vector2.right * rayright.distance, Color.red);

        Debug.DrawRay(center, -Vector2.right * rayleft.distance, Color.red);

        Debug.DrawRay(center, Vector2.up * rayup.distance, Color.red);

        Debug.DrawRay(center, -Vector2.up * raydown.distance, Color.red);

        


    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Fork")
        {
                transform.position = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y);
                rb.velocity = new Vector2(0, 0);
                canMove = true;

                //GameManager.ranPaths1();
            
            
        }

        if(col.tag == "Coin")
        {
            GameManager.location1 = Random.Range(0,65);
            GameManager.coinCount1 ++;

            GameManager.coinLo1 = new Vector3(GameManager.coinP1[GameManager.location1].transform.position.x, GameManager.coinP1[GameManager.location1].transform.position.y, GameManager.coinP1[GameManager.location1].transform.position.z);

            GameManager.coin1.transform.position = GameManager.coinLo1;

            
        }

        if(col.tag == "Clock")
        {
            StartCoroutine(Player2Controller.clock());
            Destroy(col.gameObject);
        }

        if(col.tag == "Arrows")
        {
            StartCoroutine(Player2Controller.arrows());
            Destroy(col.gameObject);
        }

        



        
    }

    /* public void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Fork")
        {
            canMove = true;
            
        }
    }*/

    public void OnTriggerExit2D(Collider2D col)
    {
        

    }

    public IEnumerator clock()
    {
        freeze = true;
        yield return new WaitForSeconds(5f);
        freeze = false;
        StopCoroutine(clock());
    }

    public IEnumerator arrows()
    {
        speed*=-1;
        yield return new WaitForSeconds(10f);
        speed*=-1;
        StopCoroutine(arrows());
    }
}
