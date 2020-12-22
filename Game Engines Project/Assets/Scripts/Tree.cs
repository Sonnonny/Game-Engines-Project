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
        if (iterations > 0) StartTree();
    }

    void StartTree()
    {
        iterations--;
        GameObject Go = Instantiate(parts[Random.Range(0,parts.Length)],transform.position,Quaternion.identity,transform);
        Go.GetComponent<Part>().Create(iterations,iterations+1);
    }

}
