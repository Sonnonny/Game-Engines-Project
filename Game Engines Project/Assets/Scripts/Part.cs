using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public int iteration;

    public GameObject[] parts;

    public Transform[] locations;

    public bool sphere;
    public Vector2 sphereRange;

    public bool cube;

    public Material[] mats;

    public void Create(int newIter, int max)
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material = mats[Random.Range(0, mats.Length)];

        Transform temptrans = transform.parent.transform;
        transform.SetParent(null);

        float height = Random.Range(1f, 2.2f);
        float dimen = Random.Range(0.6f, 1.2f);

        transform.localScale = new Vector3(dimen, height, dimen);

        transform.SetParent(temptrans,true);

        iteration = newIter;

        if (iteration <= 0) return;
        else iteration--;

        int temp = 0;

        foreach (Transform location in locations) 
        {
            if (!cube || temp == 0)
            { 
                if (iteration > 2)
                {
                    temp++;
                }
                
                GameObject Go = Instantiate(parts[Random.Range(0, parts.Length)], location.position, location.rotation, transform);
                Go.GetComponent<Part>().Create(iteration, max);
            }
            
        }
        if (sphere)
        {
            int range = (int)Random.Range(sphereRange.x, sphereRange.y);
            for (int i = 0; i < range; i++)
            {
                GameObject Go = Instantiate(parts[Random.Range(0, parts.Length)], Random.onUnitSphere*0.5f,   Random.rotation,transform);
                Go.GetComponent<Part>().Create(iteration,max);
            }
        }

    }


}
