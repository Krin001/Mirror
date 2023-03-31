using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pControl : MonoBehaviour
{
    public GameObject GameMan;

    public GameManager GameManager;

    public Player2Controller  Player2Controller;

    public Rigidbody2D rb;

    

    // Start is called before the first frame update
    void Start()
    {
        GameMan = GameObject.Find("Game Manager");
        GameManager = GameMan.GetComponent<GameManager>();
        Player2Controller = GameObject.Find("Character3").GetComponent<Player2Controller>();

        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
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
    }
}
