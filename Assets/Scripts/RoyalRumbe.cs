using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalRumbe : MonoBehaviour {

    public int danioBarril = 10;

    GameObject player;
    PlayerHealth playerHealth;

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
    } 
	// Update is called once per frame
	void Update () {
		
	}
}
