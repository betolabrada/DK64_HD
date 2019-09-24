using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public float speed = 10f;

    Rigidbody playerRigidbody;
    public bool estaEnPiso;
    int playerN;

    void Start()
    {
        estaEnPiso = true;
        playerRigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {

        if (Input.GetButtonDown("P" + playerN + "J") && estaEnPiso)
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
