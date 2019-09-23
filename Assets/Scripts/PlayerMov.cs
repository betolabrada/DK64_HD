using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour {

    public float speed = 5f;

    Rigidbody playerRigidbody;
    Vector3 movement;

    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9){
            //playerRigidbody.AddExplosionForce(10, transform.position, 5, 3.0F, ForceMode.Impulse);
            playerRigidbody.AddExplosionForce(1200, Vector3.zero, 100);
        }
    }

    // Update is called once per frame
    void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
	}

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        // normalize
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }
}
