using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Cont2 : MonoBehaviour
{
    public GameObject textCont;

    public tutorialController tutorialController;

    public P2Cont1 P2Cont1;

    public Rigidbody2D rb;

    public P1Cont1 P1Cont1;

    //Raycasts
    public float castDist;

    

    // Start is called before the first frame update
    void Start()
    {
        textCont = GameObject.Find("TextControl");
        tutorialController = textCont.GetComponent<tutorialController>();
        P2Cont1 = GameObject.Find("Character3").GetComponent<P2Cont1>();
        P1Cont1 = GameObject.Find("Character1").GetComponent<P1Cont1>();
        
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
                    P1Cont1.left = false;
                }
                else
                {
                    P1Cont1.left = true;
                }
            }
            else
            {
                P1Cont1.left = false;
            }
            
        }
        else
        {
            P1Cont1.left = true;
        }

        if(left.collider != null)
        {
            

            if(left.transform.name != "Wall")
            {
                if(left.transform.GetComponent<rPaths>().closed)
                {
                    P1Cont1.right = false;
                }
                else
                {
                    P1Cont1.right = true;
                }
            }
            else
            {
                P1Cont1.right = false;
            }
            
        }
        else
        {
            P1Cont1.right = true;
        }


        if(up.collider != null)
        {
            
            if(up.transform.name != "Wall")
            {
                if(up.transform.GetComponent<rPaths>().closed)
                {
                    P1Cont1.down = false;
                }
                else
                {
                    P1Cont1.down = true;
                }
            }
            else
            {
                P1Cont1.down = false;
            }
            
        }
        else
        {
            P1Cont1.down = true;
        }


        if(down.collider != null)
        {
            
            if(down.transform.name != "Wall")
            {
                if(down.transform.GetComponent<rPaths>().closed)
                {
                    P1Cont1.up = false;
                }
                else
                {
                    P1Cont1.up = true;
                }
            }
            else
            {
                P1Cont1.up = false;
            }
            
        }
        else
        {
            P1Cont1.up = true;
        }

        

        Debug.DrawRay(center, Vector2.right * right.distance, Color.red);

        Debug.DrawRay(center, -Vector2.right * left.distance, Color.red);

        Debug.DrawRay(center, Vector2.up * up.distance, Color.red);

        Debug.DrawRay(center, -Vector2.up * down.distance, Color.red);

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
            tutorialController.coi.Play();
            tutorialController.location1 = Random.Range(0,17);
            

            tutorialController.coinLo1 = new Vector3(tutorialController.coinP1[tutorialController.location1].transform.position.x, tutorialController.coinP1[tutorialController.location1].transform.position.y, tutorialController.coinP1[tutorialController.location1].transform.position.z);

            tutorialController.coin1.transform.position = tutorialController.coinLo1;

            
        }

        if(fork.tag == "Clock")
        {
            tutorialController.textNum++;
            tutorialController.p1clock = true;
            tutorialController.Clocks.SetActive(false);
            StartCoroutine(P2Cont1.clock());
            Destroy(fork.gameObject);
        }

        if(fork.tag == "Arrows")
        {
            tutorialController.textNum++;
            tutorialController.Arrows.SetActive(false);
            StartCoroutine(P2Cont1.arrows());
            Destroy(fork.gameObject);
        }

        if(fork.tag == "badCoin")
        {
            
            Destroy(fork.gameObject);
            
        }
    }
}
