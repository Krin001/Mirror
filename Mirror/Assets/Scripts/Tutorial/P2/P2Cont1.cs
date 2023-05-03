using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Cont1 : MonoBehaviour
{
    public GameObject Character, textCont;

    public GameObject permPath;

    public tutorialController tutorialController;

    public P1Cont1 P1Cont1;

    public Rigidbody2D rb, rb2;

    public float speed;

    public bool canMove,freeze;

    public bool up, up1, down, down1, left, left1, right, right1, reverse;


    public bool inputDelay;


    //Raycasts
    public float castDist;


    // Start is called before the first frame update
    void Start()
    {
        textCont = GameObject.Find("TextControl");
        tutorialController = textCont.GetComponent<tutorialController>();

        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        rb2 = Character.GetComponent<Rigidbody2D>();
        speed = 50f;

        P1Cont1 = GameObject.Find("Character1").GetComponent<P1Cont1>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorialController.pause == false)
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

    void FixedUpdate()
    {
        
        if(tutorialController.pause == false)
        {
            if(!freeze)
            {
                if(canMove)
                {
                    if(!inputDelay)
                    {
                        

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
            tutorialController.coi.Play();
             tutorialController.location2 = Random.Range(0,17);
            

            tutorialController.coinLo2 = new Vector3(tutorialController.coinP2[tutorialController.location2].transform.position.x, tutorialController.coinP2[tutorialController.location2].transform.position.y, tutorialController.coinP2[tutorialController.location2].transform.position.z);

            tutorialController.coin2.transform.position = tutorialController.coinLo2;

            
        }

        if(col.tag == "Clock")
        {
            tutorialController.p2clock = true;
            tutorialController.Clocks.SetActive(false);
            tutorialController.textNum++;
            StartCoroutine(P1Cont1.clock());
            Destroy(col.gameObject);
        }

        if(col.tag == "Arrows")
        {
            tutorialController.textNum++;
            tutorialController.Arrows.SetActive(false);
            StartCoroutine(P1Cont1.arrows());
            Destroy(col.gameObject);
        }

        if(col.tag == "badCoin")
        {
            
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
        tutorialController.cl2.SetActive(true);
        yield return new WaitForSeconds(5f);
        tutorialController.cl2.SetActive(false);
        freeze = false;
        StopCoroutine(clock());
    }

    public IEnumerator arrows()
    {
        reverse = true;
        tutorialController.rev2.SetActive(true);
        yield return new WaitForSeconds(.5f);
        tutorialController.rev2.SetActive(false);
        yield return new WaitForSeconds(9.5f);
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
