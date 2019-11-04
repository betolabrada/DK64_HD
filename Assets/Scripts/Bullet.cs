using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int danioDeBala = 1;
    PlayerHealth otherPlayerHealth;
    GameObject father;
    

    void Update ()
    {
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject != father)
        {
            print("collision");
            Rigidbody otherPlayer = other.gameObject.GetComponent<Rigidbody>();
            otherPlayer.AddExplosionForce(1200, Vector3.zero, 100);

            otherPlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (otherPlayerHealth.saludActual <= 0)
            {
                Destroy(other.gameObject);
            }
            otherPlayerHealth.HacerDanio(danioDeBala);

        }
    }

    public void SetFather(GameObject f)
    {
        father = f;
    }
}
