using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArm : MonoBehaviour {
    private int contador = 0;
    private Renderer renderer;
    Rigidbody playerRigidbody;

    // Use this for initialization
    void Start () {
        playerRigidbody = transform.parent.GetComponent<Rigidbody>();
        renderer = gameObject.GetComponent<Renderer>();
        renderer.enabled = false;
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == 9)
        {
            //playerRigidbody.AddExplosionForce(10, transform.position, 5, 3.0F, ForceMode.Impulse);
            playerRigidbody.AddExplosionForce(1200, Vector3.zero, 100);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(KeyCode.F)){

            renderer.enabled = true;

        }

        if (renderer.enabled == true){
            contador++;
        }

        if(contador == 10){
            renderer.enabled = false;
            contador = 0;
        }
	}
}
