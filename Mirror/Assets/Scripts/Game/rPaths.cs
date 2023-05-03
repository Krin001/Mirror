using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rPaths : MonoBehaviour
{
    SpriteRenderer spRend;
    Collider2D Coll;

    public bool closed;

    public bool sWhite;

    
    // Start is called before the first frame update
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        Coll = GetComponent<Collider2D>();
        if(sWhite)
        {
            spRend.color = Color.white;
        }
        else
        {
            spRend.color = Color.black;
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(closed)
        {
            if(sWhite)
            {
                spRend.color = Color.black;
            }
            else
            {
                spRend.color = Color.white;
            }
            
            
            Coll.isTrigger = false;
        }
        else
        {
            if(sWhite)
            {
                spRend.color = Color.white;
            }
            else
            {
                spRend.color = Color.black;
            }

            Coll.isTrigger = true;
            
        }

        
    }
}
