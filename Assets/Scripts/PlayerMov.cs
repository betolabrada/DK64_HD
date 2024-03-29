﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private Hill hill;
    public float speed;
    public float rotSpeed = 100f;
    public int playerN;
    public int hillPoints;

    private Quaternion originalRotation;
    Rigidbody playerRigidbody;
    Vector3 movement;

    public Animator animator;
    // Use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
        this.hillPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxisRaw("P" + playerN + "H");
        //float v = Input.GetAxisRaw("P" + playerN + "V");

        float h = Input.GetAxis("P" + playerN + "H");
        float v = Input.GetAxis("P" + playerN + "V");

        //  ROTACION
        float rx = Input.GetAxis("P" + playerN + "RX");
        float ry = Input.GetAxis("P" + playerN + "RY");
        if (Input.GetButton("P" + playerN + "RX"))
        {
            transform.Rotate(0, 0, rx * Time.deltaTime * rotSpeed);
        }
        if (Input.GetButton("P" + playerN + "RY"))
        {
            transform.Rotate(0, ry * Time.deltaTime * rotSpeed, 0);
        }

        if(Input.GetKeyDown("joystick " + playerN + " button 6") || Input.GetKeyDown(KeyCode.S) ){
            print("asdasd");
            print(originalRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * 1.0f);
        }
        /*
        transform.Rotate(Vector3.up, -100 * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, 100 * Time.deltaTime);
        */


        Move(h, v);

        transform.Rotate(0, rx * Time.deltaTime * rotSpeed,0);
    }

    

    void Move(float h, float v)
    {
        if(v != 0 | h!=0){
            animator.SetBool("Run", true);
        }else{
            animator.SetBool("Run", false);
        }
        movement.Set(h, 0f, v);

        // normalize
        movement = movement.normalized * speed * Time.deltaTime;

        //playerRigidbody.MovePosition(transform.position + movement);
        //transform.LookAt(movement + transform.position);
        transform.Translate(movement);


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //playerRigidbody.AddExplosionForce(10, transform.position, 5, 3.0F, ForceMode.Impulse);
            playerRigidbody.AddExplosionForce(1200, Vector3.zero, 100);
        }
        
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "hill")
        {
            hill = collision.gameObject.GetComponent<Hill>();
            print(hill.playersOnHill);
            if (hill.playersOnHill == 1)
            {
                this.hillPoints ++;
                print(hillPoints);

            }

        }
    }
}
