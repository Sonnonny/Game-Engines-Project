﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 moveDirection;
    public Rigidbody rb;
    public float moveSpeed;
    public float runMult;
    public LayerMask groundLayer;
    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;


        //Vector3 jump = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.Raycast(transform.position, -transform.up, 2,groundLayer);


            rb.AddForce(transform.up *jumpPower, ForceMode.Impulse);
            //jump = new Vector3(0, 8, 0);
        }

        //rb.velocity += (moveDirection+jump )* moveSpeed * Time.deltaTime;
        float run = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = runMult;
        }

        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * run* Time.deltaTime);
    }
}
