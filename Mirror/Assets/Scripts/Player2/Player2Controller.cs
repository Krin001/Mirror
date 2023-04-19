using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public GameObject Character, GameMan;

    public GameManager GameManager;

    public Rigidbody2D rb, rb2;

    public float speed;

    public bool canMove,freeze;

    public PlayerController  PlayerController;

    public GameObject permPath;

    public bool up, down, left, right, up1, down1, left1, right1, reverse;

    public bool inputDelay;


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

        PlayerController = GameObject.Find("Character1").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(permPath!=null)
        {
            if(transform.position == permPath.transform.position)
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
            
            
        }
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        //= Vector3.Distance(transform.position, col.transform.position);
        if(!freeze)
        {
            if(canMove)
            {
                if(!inputDelay)
                {
                    GameManager.pauseTime2 = false;

                    if(!reverse)
                    {
                        if(up&&up1)
                        {
                            if(Input.GetKey(KeyCode.W))
                            {
                                
                                rb.velocity = new Vector2(0, speed);
                                rb2.velocity = new Vector2(0, -speed);
                                canMove = false;
                                
                            }
                        }
                        
                        if(left&&left1)
                        {
                            if(Input.GetKey(KeyCode.A))
                            {
                                
                                rb.velocity = new Vector2(-speed, 0);
                                rb2.velocity = new Vector2(speed, 0);
                                canMove = false;
                                
                            }
                        }

                        if(down&&down1)
                        {
                            if(Input.GetKey(KeyCode.S))
                            {
                                
                                rb.velocity = new Vector2(0, -speed);
                                rb2.velocity = new Vector2(0, speed);
                                canMove = false;
                                
                                
                            }
                        }

                        if(right&&right1)
                        {
                            if(Input.GetKey(KeyCode.D))
                            {
                                
                                rb.velocity = new Vector2(speed, 0);
                                rb2.velocity = new Vector2(-speed, 0);
                                canMove = false;
                                
                            }
                        }
                    }
                    else
                    {
                        if(up&&up1)
                        {
                            if(Input.GetKey(KeyCode.S))
                            {
                                
                                rb.velocity = new Vector2(0, speed);
                                rb2.velocity = new Vector2(0, -speed);
                                canMove = false;
                                
                            }
                        }
                        
                        if(left&&left1)
                        {
                            if(Input.GetKey(KeyCode.D))
                            {
                                
                                rb.velocity = new Vector2(-speed, 0);
                                rb2.velocity = new Vector2(speed, 0);
                                canMove = false;
                                
                            }
                        }

                        if(down&&down1)
                        {
                            if(Input.GetKey(KeyCode.W))
                            {
                                
                                rb.velocity = new Vector2(0, -speed);
                                rb2.velocity = new Vector2(0, speed);
                                canMove = false;
                                
                                
                            }
                        }

                        if(right&&right1)
                        {
                            if(Input.GetKey(KeyCode.A))
                            {
                                
                                rb.velocity = new Vector2(speed, 0);
                                rb2.velocity = new Vector2(-speed, 0);
                                canMove = false;
                                
                            }
                        }
                    }
                }
                
            }
            else
            {
                
                GameManager.pauseTime2 = true;
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
                permPath = col.gameObject;
                transform.position = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y);
                rb.velocity = new Vector2(0, 0);
                StartCoroutine(delayInput());
                
                

                //GameManager.ranPaths2();
            
        }

        if(col.tag == "Coin")
        {
            GameManager.location2 = Random.Range(0,65);
            GameManager.coinCount2 ++;

            GameManager.coinLo2 = new Vector3(GameManager.coinP2[GameManager.location2].transform.position.x, GameManager.coinP2[GameManager.location2].transform.position.y, GameManager.coinP2[GameManager.location2].transform.position.z);

            GameManager.coin2.transform.position = GameManager.coinLo2;

            
        }

        if(col.tag == "Clock")
        {
            StartCoroutine(PlayerController.clock());
            Destroy(col.gameObject);
        }

        if(col.tag == "Arrows")
        {
            StartCoroutine(PlayerController.arrows());
            Destroy(col.gameObject);
        }

        
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Fork")
        { 
            permPath = null;
        }
        

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
        reverse = true;
        
        yield return new WaitForSeconds(10f);
        reverse = false;
        
        StopCoroutine(arrows());
    }

    public IEnumerator delayInput()
    {
        
        inputDelay = true;
        yield return new WaitForSeconds(.05f);
        inputDelay = false;
        
        StopCoroutine(delayInput());
    }

}
