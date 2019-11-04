using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {


    Rigidbody collisionRB;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 2f);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Ground")
        {
            collisionRB = other.gameObject.GetComponent<Rigidbody>();
            collisionRB.AddExplosionForce(10000f, transform.position, 0f);
        }
    }
}
