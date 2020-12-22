using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGen : MonoBehaviour
{

    public GameObject tree;
    public Vector2 range;
    public int trees;
    public int stopAttempts;

    public Vector3 center;
    public int radius;

    // Start is called before the first frame update
    void Start()
    {
        trees = (int)Random.Range(range.x, range.y);

        CreateScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateScene()
    {
        //Vector3 spherePoint;

        //Transform place;

        for (int i =0; i<trees; i++)
        {
            Vector3 spherePoint = Random.onUnitSphere;
            Instantiate(tree, center + spherePoint * radius, Quaternion.identity);
        }
    }
}
