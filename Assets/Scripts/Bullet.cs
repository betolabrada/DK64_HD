using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int danioDeBala = 1;
    public AudioClip audioClip;
    PlayerHealth otherPlayerHealth;
    GameObject father;
    AudioSource bulletAudio;
    BoxCollider monkeyCollider;
    SphereCollider bulletCollider;


    void Awake()
    {
    }

    void Start ()
    {
        monkeyCollider = father.GetComponent<BoxCollider>();
        bulletCollider = GetComponent<SphereCollider>();
        bulletAudio = GetComponent<AudioSource>();
        if (tag == "Coconut")
        {
            bulletAudio.Play();
        }

    }

    void Update ()
    {
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter(Collision other)
    {
        print("Collision con " +  other.gameObject.name);
        if (other.gameObject.tag == gameObject.tag)
        {
            //Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Player" && other.gameObject != father && gameObject.layer == 16)
        {
            if(other.gameObject.layer == 15)
            {
                if (father.gameObject.tag == "GunChida")
                {
                    danioDeBala = 3;
                    print("collision");
                }
                else
                {
                    danioDeBala = 1;
                }
                Rigidbody otherPlayer = other.gameObject.GetComponent<Rigidbody>();
                otherPlayer.AddExplosionForce(1200, Vector3.zero, 100);

                otherPlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
                if (otherPlayerHealth.saludActual <= 0)
                {
                    Destroy(other.gameObject);
                }
                otherPlayerHealth.HacerDanio(danioDeBala);

                Destroy(gameObject);
            }
          

        }


        if (other.gameObject.tag == "Player" && other.gameObject != father)
        {
            if (father.gameObject.tag == "GunChida")
            {
                danioDeBala = 3;
                print("collision");
            }
            else
            {
                danioDeBala = 1;
            }
            Rigidbody otherPlayer = other.gameObject.GetComponent<Rigidbody>();
            otherPlayer.AddExplosionForce(1200, Vector3.zero, 100);

            otherPlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (otherPlayerHealth.saludActual <= 0)
            {
                Destroy(other.gameObject);
            }
            otherPlayerHealth.HacerDanio(danioDeBala);

            Destroy(gameObject);

        }

        if (other.gameObject.tag == "Player" && other.gameObject != father && gameObject.layer == 15)
        {
            if(other.gameObject.layer == 16)
            {
                if (father.gameObject.tag == "GunChida")
                {
                    danioDeBala = 3;
                    print("collision");
                }
                else
                {
                    danioDeBala = 1;
                }
                Rigidbody otherPlayer = other.gameObject.GetComponent<Rigidbody>();
                otherPlayer.AddExplosionForce(1200, Vector3.zero, 100);

                otherPlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
                if (otherPlayerHealth.saludActual <= 0)
                {
                    Destroy(other.gameObject);
                }
                otherPlayerHealth.HacerDanio(danioDeBala);

                Destroy(gameObject);
            }
        }





        if (other.gameObject.tag == "Untagged" && other.gameObject != father)
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

    public void SetFather(GameObject f)
    {
        father = f;
    }
}
