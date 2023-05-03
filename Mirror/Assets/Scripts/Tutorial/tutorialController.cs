using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorialController : MonoBehaviour
{
    public string[]tuText;

    public TMP_Text Left;
    public TMP_Text Right;

    //Coin
    public bool startCoin;


    public int coinCount1, coinCount2, location1, location2;
    public GameObject coin1,coin2;
    public GameObject[] coinP1 = new GameObject[18];
    public GameObject[] coinP2 = new GameObject[18];
    public Vector3 coinLo1, coinLo2;

    //Power Up
    public float powerTimer; 
    public float randomPUp;
    public float powerUpLoc;
    public GameObject[]powerUp = new GameObject[5];

    //Player 1 paths
    public GameObject[]p1Path1 = new GameObject[12];
    public GameObject[]p1Path2 = new GameObject[12];
    
    

    //Player 2 paths
    public GameObject[]p2Path1 = new GameObject[12];
    public GameObject[]p2Path2 = new GameObject[12];


    //texts
    public int textNum;

    public bool p1clock, p2clock;

    public float pathTime2;
    public float pathTime1;
    public bool startPaths;

    public bool pause;
    public GameObject controls;


    public GameObject Clocks, Arrows, badcoins;

    public GameObject scCont;


    // Start is called before the first frame update
    void Start()
    {
        p1Paths();
        p2Paths();

        controls = GameObject.Find("Controls");

        controls.SetActive(false);
        Clocks.SetActive(false); 
        Arrows.SetActive(false); 
        badcoins.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if(textNum == 0)
        {
            Right.text = tuText[0];
            Left.text = tuText[1];
        }
        else if(textNum == 1)
        {
            Right.text = tuText[2];
            Left.text = "";
        }
        else if(textNum == 2)
        {
            Left.text = tuText[3];
            Right.text = "";
        }
        else if(textNum == 3)
        {
            Right.text = tuText[4];
            Left.text = tuText[4];
        }
        else if(textNum == 4)
        {
            Right.text = tuText[5];
            Left.text = tuText[6];
        }
        else if(textNum == 5)
        {
            Right.text = tuText[8];
            Left.text = tuText[7];
        }
        else if(textNum == 6)
        {
            Right.text = tuText[9];
            Left.text = tuText[10];
            if(Input.GetKeyUp(KeyCode.Space))
            {
                 startPaths = true;
            }
        }
        else if(textNum == 7)
        {
            Right.text = tuText[11];
            Left.text = tuText[11];
        }
        else if(textNum == 8)
        {
            Right.text = tuText[12];
            Left.text = tuText[12];
            
        }
        else if(textNum == 9)
        {
            Right.text = tuText[13];
            Left.text = tuText[14];
        }
        else if(textNum == 10)
        {
            Right.text = tuText[16];
            Left.text = tuText[15];
        }
        else if(textNum == 11)
        {
            Right.text = tuText[17];
            Left.text = tuText[17];
        }
        else if(textNum == 12)
        {
            Right.text = tuText[18];
            Left.text = tuText[19];
            if(Input.GetKeyUp(KeyCode.Space))
            {
                sCoins();
            }
        }
        else if(textNum == 13)
        {
            Right.text = tuText[20];
            Left.text = tuText[21];
        }
        else if(textNum == 14)
        {
            Right.text = tuText[22];
            Left.text = tuText[23];
        }
        else if(textNum == 15)
        {
            Right.text = tuText[24];
            Left.text = tuText[24];
        }
        else if(textNum == 16)
        {
            Right.text = tuText[25];
            Left.text = tuText[25];

            if(Input.GetKeyUp(KeyCode.Space))
            {
                Clocks.SetActive(true);
                
            }    
        }
        else if(textNum == 17)
        {
            Right.text = tuText[27];
            Left.text = tuText[26];
            //clock
        }
        else if(textNum == 18)
        {
            Right.text = tuText[27];
            Left.text = tuText[28];
            
        }
        else if(textNum == 19)
        {
            if(p1clock)
            {
                Right.text = tuText[30];
                Left.text = tuText[31];
            }
            else if(p2clock)
            {
                Left.text = tuText[29];
                Right.text = tuText[31];

            }

            if(Input.GetKeyUp(KeyCode.Space))
            {
                
                Arrows.SetActive(true); 
               
            } 
            
        }
        else if(textNum == 20)
        {
            Right.text = tuText[33];
            Left.text = tuText[32];
        }
        else if(textNum == 21)
        {
            Right.text = tuText[34];
            Left.text = tuText[34];
        }
        else if(textNum == 22)
        {
            Right.text = tuText[35];
            Left.text = tuText[36];

            if(Input.GetKeyUp(KeyCode.Space))
            {
                badcoins.SetActive(true);
            } 
        }
        else if(textNum == 23)
        {
            Right.text = tuText[37];
            Left.text = tuText[38];
        }
        else if(textNum == 24)
        {
            Right.text = tuText[39];
            Left.text = tuText[39];
        }
        else if(textNum == 25)
        {
            Right.text = tuText[40];
            Left.text = tuText[40];
        }
        else if(textNum == 26)
        {
            Right.text = tuText[42];
            Left.text = tuText[41];
        }
        else if(textNum == 27)
        {
            Right.text = tuText[44];
            Left.text = tuText[43];
        }
        else if(textNum == 28)
        {
            Right.text = tuText[45];
            Left.text = tuText[46];

            if(!pause)
            {
                if(Input.GetKeyUp(KeyCode.Space))
                {
                    scCont.GetComponent<sceneChange>().playGame();
                } 

                if(Input.GetKeyUp(KeyCode.Escape))
                {
                    scCont.GetComponent<sceneChange>().titleGame();
                }
            } 
        }

        if(!pause)
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                scCont.GetComponent<sceneChange>().titleGame();
            }
        }

        /*else if(textNum == 29)
        {
            
        }
        else if(textNum == 30)
        {
            
        }
        else if(textNum == 31)
        {
            
        }
        else if(textNum == 32)
        {
            
        }
        else if(textNum == 33)
        {
            
        }
        else if(textNum == 34)
        {
            
        }
        else if(textNum == 35)
        {
            
        }
        else if(textNum == 36)
        {
            
        }
        else if(textNum == 37)
        {
            
        }
        else if(textNum == 38)
        {
            
        }
        else if(textNum == 39)
        {
            
        }
        else if(textNum == 40)
        {
            
        }
        else if(textNum == 41)
        {
            
        }
        else if(textNum == 42)
        {
            
        }
        else if(textNum == 43)
        {
            
        }
        else if(textNum == 44)
        {
            
        }
        else if(textNum == 45)
        {
            
        }
        else
        {
            
        }*/

        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(!pause)
            {
                if(textNum!=17 || textNum!=20)
                {
                    if(textNum<28)
                    {
                        textNum++;
                    }
                }
                
            }
            
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            if(pause)
            {
                pause = false;
            }
            else
            {
                pause = true;
            }
        }

        if(Input.GetKeyUp(KeyCode.RightShift))
        {
            if(pause)
            {
                pause = false;
            }
            else
            {
                pause = true;
            }
        }

        if(pause)
        {
            controls.SetActive(true);
        }
        else
        {
            controls.SetActive(false);
        }

        if(!pause)
        {
            if(startPaths)
            {
                pathTime1 += Time.deltaTime;
                pathTime2 += Time.deltaTime;
                    

                if(pathTime1 >= 5)
                {
                    pathTime1 = 0;
                    ranPaths1();
                }

                if(pathTime2 >= 5)
                {
                    pathTime2 = 0;
                    ranPaths2();
                }
            }
        }

        

        
        
        
  
    }

    /*public void pow()
    {
        powerTimer = 0f;
        randomPUp = Random.Range(0,5);

        if(randomPUp == 0)
        {
            List<GameObject>powerLo = new List<GameObject>();
            for(int i = 33; i < 66; i++)
            {
                powerLo.Add(coinP2[i]);
            }
            for(int i = 33; i < 66; i++)
            {
                powerLo.Add(coinP1[i]);
            }
            powerUpLoc = Random.Range(0f,65f);
            Instantiate(powerUp[(int) randomPUp], new Vector3(powerLo[(int) powerUpLoc].transform.position.x, powerLo[(int) powerUpLoc].transform.position.y, powerLo[(int) powerUpLoc].transform.position.z), Quaternion.identity);

            

            
        }

        else if(randomPUp == 1)
        {
            List<GameObject>powerLo = new List<GameObject>();
            for(int i = 33; i < 66; i++)
            {
                powerLo.Add(coinP2[i]);
            }
            for(int i = 33; i < 66; i++)
            {
                powerLo.Add(coinP1[i]);
            }
            powerUpLoc = Random.Range(0f,65f);
            Instantiate(powerUp[(int) randomPUp], new Vector3(powerLo[(int) powerUpLoc].transform.position.x, powerLo[(int) powerUpLoc].transform.position.y, powerLo[(int) powerUpLoc].transform.position.z), Quaternion.identity);

            

            
        }

        else if(randomPUp == 2)
        {
            List<GameObject>powerLo = new List<GameObject>();
            for(int i = 0; i < 33; i++)
            {
                powerLo.Add(coinP2[i]);
            }
            for(int i = 0; i < 33; i++)
            {
                powerLo.Add(coinP1[i]);
            }
            powerUpLoc = Random.Range(0f,65f);
            Instantiate(powerUp[(int) randomPUp], new Vector3(powerLo[(int) powerUpLoc].transform.position.x, powerLo[(int) powerUpLoc].transform.position.y, powerLo[(int) powerUpLoc].transform.position.z), Quaternion.identity);

            

            
        }

        else if(randomPUp == 3)
        {
            List<GameObject>powerLo = new List<GameObject>();
            for(int i = 0; i < 33; i++)
            {
                powerLo.Add(coinP1[i]);
            }
            for(int i = 0; i < 33; i++)
            {
                powerLo.Add(coinP2[i]);
            }
            powerUpLoc = Random.Range(0f,65f);
            Instantiate(powerUp[(int) randomPUp], new Vector3(powerLo[(int) powerUpLoc].transform.position.x, powerLo[(int) powerUpLoc].transform.position.y, powerLo[(int) powerUpLoc].transform.position.z), Quaternion.identity);


            
        }
        else if(randomPUp == 4)
        {
            List<GameObject>powerLo = new List<GameObject>();
            for(int i = 0; i < 66; i++)
            {
                powerLo.Add(coinP2[i]);
            }
            for(int i = 0; i < 66; i++)
            {
                powerLo.Add(coinP1[i]);
            }
            Debug.Log(powerLo.Count);
            powerUpLoc = Random.Range(0f,131f);
            Instantiate(powerUp[(int) randomPUp], new Vector3(powerLo[(int) powerUpLoc].transform.position.x, powerLo[(int) powerUpLoc].transform.position.y, powerLo[(int) powerUpLoc].transform.position.z), Quaternion.identity);


            
        }
    }*/

    public void sCoins()
    {
        for(int i = 0; i < 18; i++)
        {
            coinP1[i] = GameObject.Find("PermanentPath (" +(i) +")");
            coinP2[i] = GameObject.Find("PermanentPath2 (" +(i) +")");
        }
        

        location1 = Random.Range(0,17);
        

        coinLo1 = new Vector3(coinP1[location1].transform.position.x, coinP1[location1].transform.position.y, coinP1[location1].transform.position.z);
        coin1.transform.position = coinLo1;

        location2 = Random.Range(0,17);
        

        coinLo2 = new Vector3(coinP2[location2].transform.position.x, coinP2[location2].transform.position.y, coinP2[location2].transform.position.z);
        coin2.transform.position = coinLo2;
    }

    public void p1Paths()
    {
        for(int i = 0; i < 12; i++)
        {
            p1Path1[i] = GameObject.Find("Paths (" +(i) +")");  
        }

        for(int i = 12; i < 24; i++)
        {
            p1Path2[i-12] = GameObject.Find("Paths (" +(i) +")");
        }

    }

    public void p2Paths()
    {
        for(int i = 0; i < 12; i++)
        {
            p2Path1[i] = GameObject.Find("Paths2 (" +(i) +")");  
        }

        for(int i = 12; i < 24; i++)
        {
            p2Path2[i-12] = GameObject.Find("Paths2 (" +(i) +")");
        }

    }

    public void ranPaths1()
    {
        List<GameObject>p1PaBla = new List<GameObject>();
        List<GameObject>p1PaWhi = new List<GameObject>();
        for(int i = 0; i < 12; i++)
        {
            p1Path1[i].GetComponent<rPaths>().closed = false;
            p1Path2[i].GetComponent<rPaths>().closed = false;
            p1PaBla.Add(p1Path1[i]);
            p1PaWhi.Add(p1Path2[i]);
        }

        for(int i = 0; i < 2; i++)
        {
            float pathNum = p1PaBla.Count;
            float close = Random.Range(0f,pathNum);

            float pathNum2 = p1PaWhi.Count;
            float close2 = Random.Range(0f,pathNum2);

            p1PaBla[(int) close].GetComponent<rPaths>().closed = true;
            p1PaBla.Remove(p1PaBla[(int) close]);

            p1PaWhi[(int) close2].GetComponent<rPaths>().closed = true;
            p1PaWhi.Remove(p1PaWhi[(int) close2]);
        }



    }

    public void ranPaths2()
    {
        List<GameObject>p2PaBla = new List<GameObject>();
        List<GameObject>p2PaWhi = new List<GameObject>();
        for(int i = 0; i < 12; i++)
        {
            p2Path1[i].GetComponent<rPaths>().closed = false;
            p2Path2[i].GetComponent<rPaths>().closed = false;
            p2PaBla.Add(p2Path1[i]);
            p2PaWhi.Add(p2Path2[i]);
        }

        for(int i = 0; i < 2; i++)
        {
            float pathNum = p2PaBla.Count;
            float close = Random.Range(0f,pathNum);

            float pathNum2 = p2PaWhi.Count;
            float close2 = Random.Range(0f,pathNum2);

            p2PaBla[(int) close].GetComponent<rPaths>().closed = true;
            p2PaBla.Remove(p2PaBla[(int) close]);

            p2PaWhi[(int) close2].GetComponent<rPaths>().closed = true;
            p2PaWhi.Remove(p2PaWhi[(int) close2]);
        }



    }
}
