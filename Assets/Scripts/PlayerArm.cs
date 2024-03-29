﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArm : MonoBehaviour {

    // todos los ataques de player: Arm, Gun, Bomb y Gun Chida

    public GameObject bala;
    public GameObject balaChida;
    public GameObject bomb;
    public float potenciaDisparo = 500f;
    public Animator animator;
    float tiempoConArmaChida = 10f;
    int playerN;
    public int danioDeGolpe = 2;

    PlayerMov playerMov;
    PlayerHealth playerHealth;
    BalasManager bm;
    ArmaChidaEnMapa acem;
    ArmaChidaScript acem2;
    GameManager gameManager;

    // children
    GameObject arm;
    GameObject gun;
    GameObject bombRef; // despues
    GameObject gunChida;
    public GameObject gameManagerObject;

    Transform gunRef;
    Transform gunChidaRef;

    bool gunActive = false;
    bool gunChidaActive = false;

    float timer;
    float tiempoEntreGolpes = 0.55f;
    float timerDisparos;
    float tiempoEntreDisparos = 0.25f;
    float gunChidaTimer;
    public AudioClip armaChida;
    void Awake()
    {

        gameManager = gameManagerObject.GetComponent<GameManager>();
        playerMov = GetComponent<PlayerMov>();
        playerHealth = GetComponent<PlayerHealth>();
        bm = GetComponent<BalasManager>();
        acem = GameObject.Find("Suelo").GetComponent<ArmaChidaEnMapa>();

        playerN = playerMov.playerN;

        arm = gameObject.transform.GetChild(0).gameObject;
        gun = gameObject.transform.GetChild(1).gameObject;
        bombRef = gameObject.transform.GetChild(2).gameObject;
        gunChida = gameObject.transform.GetChild(3).gameObject;


        gunRef = gun.gameObject.transform.GetChild(0).gameObject.transform;
        gunChidaRef = gunChida.transform.GetChild(2).gameObject.transform;


    }

    void FixedUpdate () {
        
        timer += Time.deltaTime;
        timerDisparos += Time.deltaTime;

        // golpear o disparar si arma esta activa
        if (Input.GetButtonDown("P" + playerN + "F"))
        {
            timer = 0f;
            if (!gunActive && !gunChidaActive) {arm.SetActive(true); animator.SetTrigger("Punch");}
            else if (gunActive && bm.CurrentAmmo() <= 0) ToggleGun();
            else if (gunActive && timerDisparos > tiempoEntreDisparos) DisparalaGun();
            else if (gunChidaActive) DisparalaGunChida();
        }

        // timer para golpes
        if (timer >= tiempoEntreGolpes)
        {
            arm.SetActive(false);
        }

        // sacar o guardar arma
        if (Input.GetButtonDown("P" + playerN + "P") && !gunChidaActive)
        {
            ToggleGun();
        }

        //// lanzar bomba
        //if (Input.GetButtonDown("P" + playerN + "B"))
        //{
        //    LanzaBomba();
        //}

        // arma chida tiempo
        if (gunChidaActive)
        {
            gunChidaTimer += Time.deltaTime;
            //print(gunChidaTimer);
            if (gunChidaTimer >= tiempoConArmaChida)
            {
                gunChidaActive = false;
                gunChida.SetActive(false);
                gunChidaTimer = 0f;
                acem.armaChidaStillThere = false;
                acem.ResetTimerArmaRespawn();
            }
        }




    }

    //void LanzaBomba()
    //{
    //    if (gameManager.modoActual != 8 && gameManager.modoActual != 7)
    //    {
    //        GameObject instBomba = Instantiate(bomb, bombRef.transform.position, bombRef.transform.rotation);
    //        Rigidbody instBombaRigidbody = instBomba.GetComponent<Rigidbody>();
    //        Physics.IgnoreCollision(instBomba.GetComponent<Collider>(), GetComponent<Collider>());
    //        instBombaRigidbody.AddForce(bombRef.transform.forward * 100f);
    //    }
    //}

    void DisparalaGun()
    {
        if (gameManager.modoActual != 8 && gameManager.modoActual != 7)
        {
            print("disparando");
            timerDisparos = 0f;
            GameObject instBala = Instantiate(bala, gunRef.position, gunRef.rotation);
            Physics.IgnoreCollision(instBala.GetComponent<Collider>(), GetComponent<Collider>());
            Rigidbody instBalaRigidbody = instBala.GetComponent<Rigidbody>();
            Bullet instBalaScript = instBala.GetComponent<Bullet>();
            instBalaScript.SetFather(gameObject);
            //Vector3 shootVec = instBala.transform.forward;
            //shootVec = Quaternion.Euler(0f, gun.transform.eulerAngles.y, 0f) * shootVec;

            print(gunRef.transform.forward);
            instBalaRigidbody.AddForce(gunRef.transform.up * potenciaDisparo);

            bm.Shot();
        }
   
    }

    void DisparalaGunChida()
    {
        if (gameManager.modoActual != 8 && gameManager.modoActual != 7)
        {
            GameObject instBala = Instantiate(balaChida, gunChidaRef.position, Quaternion.identity);
            Rigidbody instBalaRigidbody = instBala.GetComponent<Rigidbody>();
            Bullet instBalaScript = instBala.GetComponent<Bullet>();
            instBalaScript.danioDeBala = 2;
            instBalaScript.SetFather(gunChida);
            Vector3 shootVec = instBala.transform.forward;
            shootVec = Quaternion.Euler(0f, gunChida.transform.eulerAngles.y - 90, 0f) * shootVec;
            instBalaRigidbody.AddForce(shootVec * 20f, ForceMode.Impulse);
        }


    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && gameObject.layer != 15 && gameObject.layer != 16)
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

        if (other.gameObject.tag == "Player" && gameObject.layer == 16)
        {
            if (other.gameObject.layer == 15)
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


        if (other.gameObject.tag == "Player" && gameObject.layer == 15)
        {
            if (other.gameObject.layer == 16)
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

        if (other.gameObject.tag == "GunChida")
        {
            AudioSource sonido = gameObject.GetComponent<AudioSource>();
            print(sonido);
            sonido.PlayOneShot(armaChida, 1.0f);
            ToggleGunChida();
            Destroy(other.gameObject);
        }
    }

    public bool GunIsActive()
    {
        return gunActive;
    }

    void ToggleGunChida()
    {
        if (gameManager.modoActual != 8 && gameManager.modoActual != 7)
        {
            gun.SetActive(false);
            gunActive = false;
            gunChida.SetActive(!gunChidaActive);
            gunChida.GetComponent<BoxCollider>().enabled = false;
            gunChidaActive = !gunChidaActive;
            playerMov.speed = !gunChidaActive ? 10f : 8.5f;

        }
    }

    void ToggleGun()
    {
        if (gameManager.modoActual != 8 && gameManager.modoActual != 7)
        {
            gun.SetActive(!gunActive);
            gunActive = !gunActive;
            playerMov.speed = !gunActive ? 10f : 7.5f;
        }
            


    }

    void Update(){
        playerN = playerMov.playerN;
    }

}
