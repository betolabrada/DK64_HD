using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bariil : MonoBehaviour {
    private Rigidbody rb;
    public float radius = 5.0F;
    public float power = 10.0F;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11){
            rb.AddExplosionForce(power, transform.position, radius, 3.0F, ForceMode.Impulse);
            Destroy(gameObject, 3);
            //collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10, Vector3.zero, 10);
        } else if (collision.gameObject.layer == 12){
            rb.AddExplosionForce(power, transform.position, radius, 3.0F, ForceMode.Impulse);
            Destroy(gameObject, 3);
        } else if (collision.gameObject.layer == 13){
            rb.AddExplosionForce(power, transform.position, radius, 3.0F, ForceMode.Impulse);
            Destroy(gameObject, 3);
        }
    } 

    // Update is called once per frame
    void Update () {
		
	}
}
