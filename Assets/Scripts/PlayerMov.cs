using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour {

    public float speed;
    public int playerN;
    bool estaEnPiso;

    Rigidbody playerRigidbody;
    Vector3 movement;

    // Use this for initialization
    void Start () {
        estaEnPiso = true;
        playerRigidbody = GetComponent<Rigidbody>();
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9){
            //playerRigidbody.AddExplosionForce(10, transform.position, 5, 3.0F, ForceMode.Impulse);
            playerRigidbody.AddExplosionForce(1200, Vector3.zero, 100);
        }
        if (collision.gameObject.tag == "Ground" && !estaEnPiso)
        {
            print("en piso");
            estaEnPiso = true;
        }
    }

    // Update is called once per frame
    void Update () {
        float h = Input.GetAxisRaw("P" + playerN + "H");
        float v = Input.GetAxisRaw("P" + playerN + "V");

        //float h = Input.GetAxis("P" + playerN + "H");
        //float v = Input.GetAxis("P" + playerN + "V");

        //  ROTACION
        float rx = Input.GetAxis("P" + playerN + "RX");
        float ry = Input.GetAxis("P" + playerN + "RY");
        print("asdas");
        if (Input.GetButton("P" + playerN + "RX"))
        {
            print("sadsa");
            transform.Rotate(0, 0, rx * Time.deltaTime * 1000);
        }
        if (Input.GetButton("P" + playerN + "RY"))
        {
            print("sadssadsadasa");
            transform.Rotate(0, ry * Time.deltaTime * 1000, 0);
        }

        /*
        transform.Rotate(Vector3.up, -100 * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, 100 * Time.deltaTime);
        */

        
        Move(h, v);
        transform.Rotate(0, rx * Time.deltaTime * 1000, ry * Time.deltaTime * 1000);
    }

    void FixedUpdate()
    {

        if (Input.GetButtonDown("P" + playerN + "J") && estaEnPiso)
        {
            Jump();
            estaEnPiso = false;
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        // normalize
        movement = movement.normalized * speed * Time.deltaTime;

        //playerRigidbody.MovePosition(transform.position + movement);
        transform.LookAt(movement + transform.position);
        transform.Translate(movement, Space.World);
    }

    void Jump()
    {
        playerRigidbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
    }
    
}
