using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rPaths : MonoBehaviour
{
    SpriteRenderer spRend;
    Collider2D Coll;

    public bool closed;

    
    // Start is called before the first frame update
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        Coll = GetComponent<Collider2D>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(closed)
        {
            spRend.enabled = false;
            Coll.isTrigger = false;
        }
        else
        {
            Coll.isTrigger = true;
            spRend.enabled = true;
        }
    }
}
