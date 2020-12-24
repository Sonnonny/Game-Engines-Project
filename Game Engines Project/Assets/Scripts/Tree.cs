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

    public bool master;

    static float sizeMult;

    public int treeSet;

    //public WorldGravity worldGravity;

    // Start is called before the first frame update
    void Start()
    {
        

        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

        foreach(GameObject tree in trees)
        {
            if (tree != gameObject)
            {
                if (Vector3.Distance(transform.position, tree.transform.position) < (10)*(0.5f + 600-treeSet)/300) Destroy(gameObject);
            }
        }
        //treeAmount++;
        
        int mult = (600 - treeSet) / 100;
        int calc = (int)Mathf.Round(mult);

        iterations = 1 + calc;//Random.Range(1+calc,1+5*calc);
        //Debug.Log(treeSet + "       " +(1+calc) +" "+(1+5*calc) + "         " + iterations);
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


    private void Update()
    {
        if (master) 
        {
            float[] spectrum = new float[256];

            AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

            //for (int i = 1; i < spectrum.Length - 1; i++)
            //{
            //    sizeMult = 1 + spectrum[i] * 500;

            //}

            sizeMult = 1 + spectrum[(int)Mathf.Round(Time.time%(spectrum.Length-1))] * 60;
        }

        transform.localScale = new Vector3(sizeMult, sizeMult, sizeMult);

    }

}
