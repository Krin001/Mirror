using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int coinCount,location;
    public GameObject coin;

    
    public GameObject[] coinP = new GameObject[20];
    public Vector3 coinLo;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            coinP[i] = GameObject.Find("CoinLocation (" +(i+1) +")");
        }
        

        location = Random.Range(0,19);
        coinCount = 0;

        coinLo = new Vector3(coinP[location].transform.position.x, coinP[location].transform.position.y, coinP[location].transform.position.z);

        coin.transform.position = coinLo;




    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(coinCount);
        
    }


}
