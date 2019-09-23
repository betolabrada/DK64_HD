using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public float speed = 10f;

    Rigidbody playerRigidbody;
    public bool estaEnPiso;

    void Start()
    {
        estaEnPiso = true;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (Input.GetButtonDown("Jump") && estaEnPiso)
        {
            Jump();
            estaEnPiso = false;
        }
    }

    void Jump()
    {
        playerRigidbody.AddForce(new Vector3(0,10,0), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Ground" && !estaEnPiso)
        {
            print("en piso");
            estaEnPiso = true;
        }
    }

}
