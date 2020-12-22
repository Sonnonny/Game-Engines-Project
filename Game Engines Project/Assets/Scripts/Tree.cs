using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public GameObject[] parts;

    public int iterations;
    public Vector2 minMax;


    // Start is called before the first frame update
    void Start()
    {
        iterations = (int)Random.Range(minMax.x, minMax.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
