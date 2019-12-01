using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandiaVida : MonoBehaviour
{
    public int unidadesDeVida = 1;
    AudioSource audioSrc;
    MeshRenderer sandiaRnd;
    CapsuleCollider sandiaColl;


    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        sandiaRnd = transform.GetChild(0).GetComponent<MeshRenderer>();
        sandiaColl = GetComponent<CapsuleCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSrc.Play();
            other.gameObject.GetComponent<PlayerHealth>().RecuperarVida(unidadesDeVida);
            sandiaRnd.enabled = false;
            sandiaColl.enabled = false;
            StartCoroutine("Respawn");
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);
        sandiaRnd.enabled = true;
        sandiaColl.enabled = true;
    }


}
