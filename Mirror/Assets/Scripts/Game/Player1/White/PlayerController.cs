
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

    public GameObject permPath;

    public bool up, up1, down, down1, left, left1, right, right1, reverse;


    public bool inputDelay;


    //Raycasts
    public float castDist;

    public AudioSource bump;

   

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
    }

    void Update()
    {
        if(GameManager.pause == false)
        {
            if(GameManager.canStart)
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
        }
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.pause == false)
        {
            if(GameManager.canStart)
            {
                //= Vector3.Distance(transform.position, col.transform.position);
                if(!freeze)
                {
                    if(canMove)
                    {
                        if(!inputDelay)
                        {
                            GameManager.pauseTime1 = false;

                            if(!reverse)
                            {
                                if(up&&up1)
                                {
                                    if(Input.GetKey("up"))
                                    {
                                        
                                        rb.velocity = new Vector2(0, speed);
                                        rb2.velocity = new Vector2(0, -speed);
                                        canMove = false;
                                        
                                    }
                                }
                                else if(!up&&!up1)
                                {
                                    if(Input.GetKey("up"))
                                    {
                                        
                                        bump.Play();
                                        
                                    }
                                }

                                
                                if(left&&left1)
                                {
                                    if(Input.GetKey("left"))
                                    {
                                        
                                        rb.velocity = new Vector2(-speed, 0);
                                        rb2.velocity = new Vector2(speed, 0);
                                        canMove = false;
                                        
                                    }
                                }
                                else if(!left&&!left1)
                                {
                                    if(Input.GetKey("left"))
                                    {
                                        
                                        bump.Play();
                                        
                                    }
                                }

                                if(down&&down1)
                                {
                                    if(Input.GetKey("down"))
                                    {
                                        
                                        rb.velocity = new Vector2(0, -speed);
                                        rb2.velocity = new Vector2(0, speed);
                                        canMove = false;
                                        
                                        
                                    }
                                }
                                else if(!down&&!down1)
                                {
                                    if(Input.GetKey("down"))
                                    {
                                        
                                        bump.Play();
                                        
                                    }
                                }

                                if(right&&right1)
                                {
                                    if(Input.GetKey("right"))
                                    {
                                        
                                        rb.velocity = new Vector2(speed, 0);
                                        rb2.velocity = new Vector2(-speed, 0);
                                        canMove = false;
                                        
                                    }
                                }
                                else if(!right&&!right1)
                                {
                                    if(Input.GetKey("right"))
                                    {
                                        
                                        bump.Play();
                                        
                                    }
                                }
                            }
                            else
                            {
                                if(up&&up1)
                                {
                                    if(Input.GetKey("down"))
                                    {
                                        
                                        rb.velocity = new Vector2(0, speed);
                                        rb2.velocity = new Vector2(0, -speed);
                                        canMove = false;
                                        
                                    }
                                }
                                else if(!up&&!up1)
                                {
                                    if(Input.GetKey("down"))
                                    {
                                        
                                        bump.Play();
                                        
                                    }
                                }
                                
                                if(left&&left1)
                                {
                                    if(Input.GetKey("right"))
                                    {
                                        
                                        rb.velocity = new Vector2(-speed, 0);
                                        rb2.velocity = new Vector2(speed, 0);
                                        canMove = false;
                                        
                                    }
                                }
                                else if(!right&&!right1)
                                {
                                    if(Input.GetKey("right"))
                                    {
                                        
                                        bump.Play();
                                        
                                    }
                                }


                                if(down&&down1)
                                {
                                    if(Input.GetKey("up"))
                                    {
                                        
                                        rb.velocity = new Vector2(0, -speed);
                                        rb2.velocity = new Vector2(0, speed);
                                        canMove = false;
                                        
                                        
                                    }
                                }
                                else if(!down&&!down1)
                                {
                                    if(Input.GetKey("up"))
                                    {
                                        
                                        bump.Play();
                                        
                                    }
                                }

                                if(right&&right1)
                                {
                                    if(Input.GetKey("left"))
                                    {
                                        
                                        rb.velocity = new Vector2(speed, 0);
                                        rb2.velocity = new Vector2(-speed, 0);
                                        canMove = false;
                                        
                                    }
                                }
                                else if(!right&&!right1)
                                {
                                    if(Input.GetKey("left"))
                                    {
                                        
                                        bump.Play();
                                        
                                    }
                                }
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
        }

    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Fork")
        {
                permPath = col.gameObject;
                transform.position = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y);
                rb.velocity = new Vector2(0, 0);
                StartCoroutine(delayInput());
                
            
            
        }

        if(col.tag == "Coin")
        {
            GameManager.coi.Play();
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

        if(col.tag == "badCoin")
        {
            GameManager.coi.Play();
            GameManager.coinCount2--;
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
        GameManager.cl.SetActive(true); 
        yield return new WaitForSeconds(5f);
        GameManager.cl.SetActive(false); 
        freeze = false;
        StopCoroutine(clock());
    }

    public IEnumerator arrows()
    {
        reverse = true;
        
        GameManager.rev.SetActive(true); 
        yield return new WaitForSeconds(.5f);
        
        
        yield return new WaitForSeconds(9.5f);
        GameManager.rev.SetActive(false);
        reverse = false;
        
        StopCoroutine(arrows());
    }

    public IEnumerator delayInput()
    {
        
        inputDelay = true;
        yield return new WaitForSeconds(.08f);
        inputDelay = false;
        
        StopCoroutine(delayInput());
    }
}
