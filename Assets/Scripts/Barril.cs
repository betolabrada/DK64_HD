using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour {
    private Rigidbody rb;
    public float radius = 5.0F;
    public float power = 10.0F;
    public int danioBarril = 2;

    GameObject player;
    PlayerHealth playerHealth;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();
    }
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth.saludActual > 0)
            {
                playerHealth.HacerDanio(danioBarril);
            }
        }
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
