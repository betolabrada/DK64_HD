using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public GameObject hermano;
    private Rigidbody rb;
    private float timeStamp;
    private bool active;

    // Use this for initialization
    void Start(){
        rb = GetComponent<Rigidbody>();
        active = true;
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Player")
        {
            if(timeStamp <= Time.time) {
                col.gameObject.transform.position = hermano.transform.position;
                active = false;
                timeStamp = Time.time + 4;
            }
            
        }
    }



    // Update is called once per frame
    void Update ()
    {
        
       
    }
}
