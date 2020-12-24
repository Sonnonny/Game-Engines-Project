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

    public bool react;

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


    private void Update()
    {
        if (!react) return;
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.Log(spectrum[i]);

            //transform.localScale = new Vector3(500*spectrum[i],500*spectrum[i],500*spectrum[i]);

            //Debug.Log("help");

            //Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            //Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            //Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            //Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
        
    }

}
