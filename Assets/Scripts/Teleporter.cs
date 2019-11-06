using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public GameObject hermano;
    private Rigidbody rb;

    // Use this for initialization
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Players")
        {
            col.gameObject.transform.position = hermano.transform.position;
        }
    }



    // Update is called once per frame
    void Update ()
    {
		
    }
}
