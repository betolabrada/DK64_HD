using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public float speed = 10f;
    public Animator animator;


    Rigidbody playerRigidbody;
    public bool estaEnPiso;
    int playerN;

    PlayerMov pMov;

    void Start()
    {
        pMov = GetComponent<PlayerMov>();
        playerN = pMov.playerN;
        estaEnPiso = true;
        playerRigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {

        if (Input.GetButtonDown("P" + playerN + "J") && estaEnPiso)
        {
            Jump();
        }
    }

    void Jump()
    {
        estaEnPiso = false;
        playerRigidbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        animator.SetTrigger("Jump");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && !estaEnPiso)
        {
            print("en piso");
            estaEnPiso = true;
        }
    }

}
