using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArm : MonoBehaviour {

    public int danioDeGolpe = 2;
    public float tiempoEntreGolpes = 0.25f;
    public int playerN;
    public GameObject bala;

    Rigidbody playerRigidbody;
    
    PlayerMov playerMov;
    PlayerHealth playerHealth;

    float timer;

    GameObject arm;
    GameObject gun;
    Transform gunRef;

    bool gunActive = false;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        playerMov = GetComponent<PlayerMov>();
        playerHealth = GetComponent<PlayerHealth>();
        playerN = playerMov.playerN;
        playerRigidbody = GetComponent<Rigidbody>();

        arm = gameObject.transform.GetChild(0).gameObject;
        gun = gameObject.transform.GetChild(1).gameObject;
        gunRef = gun.gameObject.transform.GetChild(0).gameObject.transform;


    }

    void Update () {

        timer += Time.deltaTime;
        //print(timer);

        // golpear
        if (Input.GetButtonDown("P" + playerN + "F"))
        {
            timer = 0f;
            // set active arm
            if (!gunActive) arm.SetActive(true);
            else DisparalaGun();
        }

        if (timer >= tiempoEntreGolpes)
        {
            arm.SetActive(false);
        }

        // sacar arma
        if (Input.GetButtonDown("P" + playerN + "P"))
        {
            if (!gunActive) SacalaGun();
            else GuardalaGun();
        }



    }

    void DisparalaGun()
    {
        GameObject instBala = Instantiate(bala, gunRef.position, Quaternion.identity);
        Rigidbody instBalaRigidbody = instBala.GetComponent<Rigidbody>();
        Vector3 shootVec = instBala.transform.forward;
        shootVec = Quaternion.Euler(0f, gun.transform.eulerAngles.y, 0f) * shootVec;

        instBalaRigidbody.AddForce(shootVec * 20f, ForceMode.Impulse);
    }
    void GuardalaGun()
    {
        gun.SetActive(false);
        gunActive = false;
        playerMov.speed = 15f;
    }

    void SacalaGun()
    {
        if (!gunActive)
        {
            gun.SetActive(true);
            gunActive = true;
        }
        playerMov.speed = 7.5f;
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
            playerHealth.HacerDanio(danioDeGolpe);

        }
    }
}
