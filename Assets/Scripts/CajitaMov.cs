using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajitaMov : MonoBehaviour {

    AudioSource audioSrc;

	void Update()
    {
        audioSrc = GetComponent<AudioSource>();
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            BalasManager bm = other.gameObject.GetComponent<BalasManager>();
            PlayerArm pa = other.gameObject.GetComponent<PlayerArm>();
            audioSrc.Play();
            bm.StartCoroutine("RechargeGun");
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("Respawn");
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }


}
