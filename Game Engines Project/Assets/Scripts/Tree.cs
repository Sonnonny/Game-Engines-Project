using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public static int treeAmount;


    public GameObject[] parts;

    public int iterations;
    public Vector2 minMax;

    List<GameObject> others;

    //public WorldGravity worldGravity;

    // Start is called before the first frame update
    void Start()
    {
        

        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

        foreach(GameObject tree in trees)
        {
            if (tree != gameObject)
            {
                if (Vector3.Distance(transform.position, tree.transform.position) < 10) Destroy(gameObject);
            }
        }
        //treeAmount++;
        


        iterations = (int)Random.Range(minMax.x, minMax.y);
        if (iterations > 0) StartTree();



        Invoke("SetRotation", 0.02f);
    }


    void SetRotation()
    {
        GameObject.FindGameObjectWithTag("World").GetComponent<WorldGravity>().Attract(transform, false);
        //Debug.Log(treeAmount);
    }

    void StartTree()
    {
        iterations--;
        GameObject Go = Instantiate(parts[Random.Range(0,parts.Length)],transform.position,Quaternion.identity,transform);
        Go.GetComponent<Part>().Create(iterations,iterations+1);
    }

}
