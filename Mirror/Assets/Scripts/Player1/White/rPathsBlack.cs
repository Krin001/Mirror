using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rPathsBlack : MonoBehaviour
{
    SpriteRenderer spRen;
    Collider2D Col;

    public bool closed;

    
    // Start is called before the first frame update
    void Start()
    {
        spRen = GetComponent<SpriteRenderer>();
        Col = GetComponent<Collider2D>();

        spRen.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if(closed)
        {
            spRen.color = Color.white;
            Col.isTrigger = false;
        }
        else
        {
            Col.isTrigger = true;
            spRen.color = Color.black;
        }
    }
}

