using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaChidaShoot : MonoBehaviour {


    public int playerN;

    AudioSource armaAudio;

    void Start ()
    {
        armaAudio = GetComponent<AudioSource>();
    }
	void Update () {
		if (Input.GetButton("P" + playerN + "F"))
        {
            armaAudio.Play();
        }
	}
}
