using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource select;
    // Start is called before the first frame update
    void Start()
    {
        select = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void choose()
    {
        select.Play();
    }
}
