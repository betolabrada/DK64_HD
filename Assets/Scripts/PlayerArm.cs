using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArm : MonoBehaviour {

    // todos los ataques de player: Arm, Gun, Bomb y Gun Chida

    public GameObject bala;
    public GameObject bomb;
    public Animator animator;
    float tiempoConArmaChida = 10f;
    int playerN;
    int danioDeGolpe = 2;

    PlayerMov playerMov;
    PlayerHealth playerHealth;
    BalasManager bm;
    ArmaChidaEnMapa acem;

    // children
    GameObject arm;
    GameObject gun;
    GameObject bombRef; // despues
    GameObject gunChida;

    Transform gunRef;
    Transform gunChidaRef;

    bool gunActive = false;
    bool gunChidaActive = false;

    float timer;
    float tiempoEntreGolpes = 0.55f;
    float gunChidaTimer;
    public AudioClip armaChida;
    void Awake()
    {
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

        // golpear o disparar si arma esta activa
        if (Input.GetButtonDown("P" + playerN + "F"))
        {
            timer = 0f;
            if (!gunActive && !gunChidaActive) {arm.SetActive(true); animator.SetTrigger("Punch");}
            else if (gunActive && bm.CurrentAmmo() <= 0) ToggleGun();
            else if (gunActive) DisparalaGun();
            else DisparalaGunChida();
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

        // lanzar bomba
        if (Input.GetButtonDown("P" + playerN + "B"))
        {
            LanzaBomba();
        }

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

    void LanzaBomba()
    {
        GameObject instBomba = Instantiate(bomb, bombRef.transform.position, Quaternion.identity);
        Rigidbody instBombaRigidbody = instBomba.GetComponent<Rigidbody>();


        instBombaRigidbody.AddForce(instBomba.transform.forward * 10f, ForceMode.Impulse);
    }

    void DisparalaGun()
    {
        print("disparando");
        GameObject instBala = Instantiate(bala, gunRef.position, Quaternion.identity);
        Rigidbody instBalaRigidbody = instBala.GetComponent<Rigidbody>();
        Bullet instBalaScript = instBala.GetComponent<Bullet>();
        instBalaScript.SetFather(gameObject);
        Vector3 shootVec = instBala.transform.forward;
        shootVec = Quaternion.Euler(0f, gun.transform.eulerAngles.y, 0f) * shootVec;

        instBalaRigidbody.AddForce(shootVec * 20f, ForceMode.Impulse);

        bm.Shot();
    }

    void DisparalaGunChida()
    {
        GameObject instBala = Instantiate(bala, gunChidaRef.position, Quaternion.identity);
        Rigidbody instBalaRigidbody = instBala.GetComponent<Rigidbody>();
        Bullet instBalaScript = instBala.GetComponent<Bullet>();
        instBalaScript.SetFather(gunChida);
        Vector3 shootVec = instBala.transform.forward;
        shootVec = Quaternion.Euler(0f, gunChida.transform.eulerAngles.y - 90, 0f) * shootVec;

        instBalaRigidbody.AddForce(shootVec * 20f, ForceMode.Impulse);

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

        if (other.gameObject.tag == "GunChida")
        {
            if (!gunChidaActive) {
                AudioSource sonido = gameObject.GetComponent<AudioSource>();
                print(sonido);
                sonido.PlayOneShot(armaChida, 1.0f);
                ToggleGunChida();
                Destroy(other.gameObject);
            }
        }
    }

    public bool GunIsActive()
    {
        return gunActive;
    }

    void ToggleGunChida()
    {
        gun.SetActive(false);
        gunActive = false;
        gunChida.SetActive(!gunChidaActive);
        gunChida.GetComponent<BoxCollider>().enabled = false;
        gunChidaActive = !gunChidaActive;
        playerMov.speed = !gunChidaActive ? 10f : 8.5f;


    }

    void ToggleGun()
    {
        gun.SetActive(!gunActive);
        gunActive = !gunActive;
        playerMov.speed = !gunActive ? 10f : 7.5f;


    }


}
