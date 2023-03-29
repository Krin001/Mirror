
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

    //public bool up, up2, down, down2, left, left2, right, right2;

   

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
        

        //= Vector3.Distance(transform.position, col.transform.position);
        if(canMove)
        {
            GameManager.pauseTime1 = false;

            /*if(up&&up2)
            {*/
                if(Input.GetKey(KeyCode.UpArrow))
                {
                    
                    rb.velocity = new Vector2(0, 20);
                    rb2.velocity = new Vector2(0, -20);
                    canMove = false;
                }
            /*}
            
            if(left&&left2)
            {*/
                if(Input.GetKey(KeyCode.LeftArrow))
                {
                    
                    rb.velocity = new Vector2(-20, 0);
                    rb2.velocity = new Vector2(20, 0);
                    canMove = false;
                }
            /*}

            if(down&&down2)
            {*/
                if(Input.GetKey(KeyCode.DownArrow))
                {
                    
                    rb.velocity = new Vector2(0, -20);
                    rb2.velocity = new Vector2(0, 20);
                    canMove = false;
                    
                }
            /*}

            if(right&&right2)
            {*/
                if(Input.GetKey(KeyCode.RightArrow))
                {
                    
                    rb.velocity = new Vector2(20, 0);
                    rb2.velocity = new Vector2(-20, 0);
                    canMove = false;
                }
            //}
        }
        else
        {
            GameManager.pauseTime1 = true;
        }

        
        
    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Fork")
        {
                transform.position = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y);
                rb.velocity = new Vector2(0, 0);
                
                
                
                canMove = true;
            
            
        }

        if(col.tag == "Coin")
        {
            GameManager.location1 = Random.Range(0,19);
            GameManager.coinCount1 ++;

            GameManager.coinLo1 = new Vector3(GameManager.coinP1[GameManager.location1].transform.position.x, GameManager.coinP1[GameManager.location1].transform.position.y, GameManager.coinP1[GameManager.location1].transform.position.z);

            GameManager.coin1.transform.position = GameManager.coinLo1;

            
        }

        
    }

     public void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Fork")
        {
                
                //rb2.velocity = new Vector2(0, 0);
                
                
                canMove = true;
            
            
        }
    }
}
