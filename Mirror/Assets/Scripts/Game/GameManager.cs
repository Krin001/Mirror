using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int coinCount1, coinCount2, location1, location2;
    public GameObject coin1,coin2;
    public GameObject[] coinP1 = new GameObject[66];
    public GameObject[] coinP2 = new GameObject[66];
    public Vector3 coinLo1, coinLo2;

    public float powerTimer; 
    public float randomPUp;
    public float powerUpLoc;
    public GameObject[]powerUp = new GameObject[5];

    //Player 1 paths
    public float pathTime1;

    public bool pauseTime1 = false;
    
    public GameObject[]p1Path1 = new GameObject[44];

    public GameObject[]p1Path2 = new GameObject[44];
    
    

    //Player 2 paths
    public float pathTime2;

    public bool pauseTime2 = false;
    
    public GameObject[]p2Path1 = new GameObject[44];
    public GameObject[]p2Path2 = new GameObject[44];


    //Text
    public float gameTime = 180f;
    public TMP_Text timer;
    public string timeLeft = "Time left: 180 second";

    public TMP_Text p1CC;
    public string play1CC = "P1 Coins: = 0";

    public TMP_Text p2CC;
    public string play2CC = "P2 Coins: = 0";

    //Starting timer
    public GameObject startingTime;
    public float startTime = 5;
    public bool canStart;
    public TMP_Text startDelay;

    public bool pause;
    public GameObject controls;
    public GameObject scCont;

    //power ups
    public GameObject rev,rev2,cl,cl2;
     public AudioSource coi; 
    
    
    


    // Start is called before the first frame update
    void Start()
    {
        startingTime.SetActive(true);
        controls.SetActive(false);
        p1Paths();
        p2Paths();

        for(int i = 0; i < 66; i++)
        {
            coinP1[i] = GameObject.Find("permanentPath (" +(i) +")");
            coinP2[i] = GameObject.Find("PermanentPath2 (" +(i) +")");
        }
        

        location1 = Random.Range(0,65);
        coinCount1 = 0;

        coinLo1 = new Vector3(coinP1[location1].transform.position.x, coinP1[location1].transform.position.y, coinP1[location1].transform.position.z);
        coin1.transform.position = coinLo1;

        location2 = Random.Range(0,65);
        coinCount2 = 0;

        coinLo2 = new Vector3(coinP2[location2].transform.position.x, coinP2[location2].transform.position.y, coinP2[location2].transform.position.z);
        coin2.transform.position = coinLo2;

       

        timer.text = timeLeft;
        p1CC.text = play1CC;
        p2CC.text = play2CC;

        rev.SetActive(false); 
        rev2.SetActive(false); 
        cl.SetActive(false);
        cl2.SetActive(false);




    }

    // Update is called once per frame
    void Update()
    {
        if(!pause)
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                scCont.GetComponent<sceneChange>().titleGame();
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

        p1CC.text = "P1 Coins: = " + coinCount1;

        p2CC.text = "P2 Coins: = " + coinCount2;

        if(!pause)
        {
            if(canStart)
            {
                if(gameTime>=0)
                {
                    gameTime -= Time.deltaTime;
                    int time = Mathf.RoundToInt(gameTime);
                    timer.text = "Time Left: " +time;

                }
                else
                {
                    Player2Controller p2C = GameObject.Find("Character3").GetComponent<Player2Controller>();
                    PlayerController p1C = GameObject.Find("Character1").GetComponent<PlayerController>();
                    p2C.canMove = false;
                    
                    
                    p1C.canMove = false;

                    if(coinCount1>coinCount2)
                    {
                        timer.text = "P1 wins!";
                    }
                    else if(coinCount1<coinCount2)
                    {
                        timer.text = "P2 wins!";
                    }
                    else
                    {
                        timer.text = "Wow its a tie!";
                    }
                }
                




                

                /*if(pauseTime1 == false)
                {
                    
                }

                if(pauseTime2 == false)
                {
                    
                }*/

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


                powerTimer += Time.deltaTime;
                
                if(powerTimer >= 5)
                {
                    pow();
                }
                
                
            }
            else
            {
                startTime-=Time.deltaTime;
                int sT = Mathf.RoundToInt(startTime);
                startDelay.text = sT.ToString();

                if(sT == 0)
                {
                    canStart = true;
                    startDelay.enabled = false;
                    startingTime.SetActive(false);
                }
            }
        }
        
    }

    public void pow()
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
    }

    public void p1Paths()
    {
        for(int i = 0; i < 44; i++)
        {
            p1Path1[i] = GameObject.Find("Path (" +(i+1) +")");  
        }

        for(int i = 45; i < 89; i++)
        {
            p1Path2[i-45] = GameObject.Find("Path (" +(i) +")");
        }

    }

    public void p2Paths()
    {
        for(int i = 0; i < 44; i++)
        {
            p2Path1[i] = GameObject.Find("Paths2 (" +(i) +")");  
        }

        for(int i = 44; i < 88; i++)
        {
            p2Path2[i-44] = GameObject.Find("Paths2 (" +(i) +")");
        }

    }

    public void ranPaths1()
    {
        List<GameObject>p1PaBla = new List<GameObject>();
        List<GameObject>p1PaWhi = new List<GameObject>();
        for(int i = 0; i < 44; i++)
        {
            p1Path1[i].GetComponent<rPaths>().closed = false;
            p1Path2[i].GetComponent<rPaths>().closed = false;
            p1PaBla.Add(p1Path1[i]);
            p1PaWhi.Add(p1Path2[i]);
        }

        for(int i = 0; i < 4; i++)
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
        for(int i = 0; i < 44; i++)
        {
            p2Path1[i].GetComponent<rPaths>().closed = false;
            p2Path2[i].GetComponent<rPaths>().closed = false;
            p2PaBla.Add(p2Path1[i]);
            p2PaWhi.Add(p2Path2[i]);
        }

        for(int i = 0; i < 4; i++)
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
