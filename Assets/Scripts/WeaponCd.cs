using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCd : MonoBehaviour {
    private Rigidbody rb;
    private float timeStamp;
    private bool active;
    AudioSource playerAudio;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        active = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (timeStamp <= Time.time)
            {
                //  activar arma chida en jugador
                gameObject.GetComponent<Renderer>().enabled = false;
                playerAudio.Play();
                active = false;
                timeStamp = Time.time + 8;
            }

        }
    }


    // Update is called once per frame
    void Update () {
        if (timeStamp <= Time.time)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
