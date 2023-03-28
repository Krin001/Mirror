using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public GameObject GameMan;

    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameMan = GameObject.Find("Game Manager");
        GameManager = GameMan.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D fork)
    {
        if(fork.tag == "Fork")
        {
            transform.position = new Vector2(fork.gameObject.transform.position.x, fork.gameObject.transform.position.y); 
        }

        if(fork.tag == "Coin")
        {
            GameManager.location = Random.Range(0,19);
            GameManager.coinCount ++;

            GameManager.coinLo = new Vector3(GameManager.coinP[GameManager.location].transform.position.x, GameManager.coinP[GameManager.location].transform.position.y, GameManager.coinP[GameManager.location].transform.position.z);

            GameManager.coin.transform.position = GameManager.coinLo;

            
        }
    }
}
