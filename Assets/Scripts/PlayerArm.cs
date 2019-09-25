using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArm : MonoBehaviour {

    public int golpe = 2;
    public float tiempoEntreGolpes = 0.25f;

    private int contador = 0;
    Rigidbody playerRigidbody;
    

    public GameObject player;
    PlayerMov playerMov;
    PlayerHealth playerHealth;
    float timer;
    public int playerN;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        playerMov = player.GetComponent<PlayerMov>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerN = playerMov.playerN;
    }

    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
        print(transform.childCount);
        //renderer = gameObject.GetComponent<Renderer>();
        //renderer.enabled = false;
    }


    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;
        //print(timer);
        if (Input.GetButtonDown("P" + playerN + "F"))
        {
            timer = 0f;
            // set active arm
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (timer >= tiempoEntreGolpes)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }



    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody otherPlayer = other.gameObject.GetComponent<Rigidbody>();
            otherPlayer.AddExplosionForce(1200, Vector3.zero, 100);
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth.saludActual <= 0)
            {
                Destroy(other);
            }
            playerHealth.HacerDanio(golpe);

        }
    }
}
