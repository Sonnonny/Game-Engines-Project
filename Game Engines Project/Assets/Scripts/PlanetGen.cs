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

    public MeshRenderer meshRen;
    public Material[] mats;

    // Start is called before the first frame update
    void Start()
    {

        meshRen.material = mats[Random.Range(0, mats.Length)];
        meshRen.material.SetColor("_ColorTint", new Color(Random.value,Random.value,Random.value,1));


        //range = new Vector2(Random.Range(50,150), Random.Range(150,600));

        trees = Random.Range(50,600);

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
            GameObject go = Instantiate(tree, center + spherePoint * radius, Quaternion.identity, transform);
            go.GetComponent<Tree>().treeSet = trees;
        }
    }
}
