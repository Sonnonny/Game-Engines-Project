using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public WorldGravity attractorPlanet;
    private Transform playerTransform;

    void Start()
    {
        attractorPlanet = GameObject.FindGameObjectWithTag("World").GetComponent<WorldGravity>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    void FixedUpdate()
    {
        if (attractorPlanet)
        {
            attractorPlanet.Attract(playerTransform,true);
        }
    }
}
