using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p4Control : MonoBehaviour
{
   public GameObject GameMan;

    public GameManager GameManager;

    public Rigidbody2D rb;

    public PlayerController  PlayerController;

    

    // Start is called before the first frame update
    void Start()
    {
        GameMan = GameObject.Find("Game Manager");
        GameManager = GameMan.GetComponent<GameManager>();
         PlayerController = GameObject.Find("Character1").GetComponent<PlayerController>();
        
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
