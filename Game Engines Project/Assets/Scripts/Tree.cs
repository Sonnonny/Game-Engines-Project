using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public GameObject[] parts;

    public int iterations;
    public Vector2 minMax;

    List<GameObject> others;

    //public WorldGravity worldGravity;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("World").GetComponent<WorldGravity>().Attract(transform,false);

        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

        foreach(GameObject tree in trees)
        {
            if (tree != gameObject)
            {
                if (Vector3.Distance(transform.position, tree.transform.position) < 10) Destroy(gameObject);
            }
        }

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
