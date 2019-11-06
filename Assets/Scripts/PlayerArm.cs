using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArm : MonoBehaviour {

    // todos los ataques de player: Arm, Gun y Bomb

    public int danioDeGolpe = 2;
    public float tiempoEntreGolpes = 0.25f;
    public int playerN;
    public GameObject bala;
    public GameObject bomb;

    public Text balaText;   
    Rigidbody playerRigidbody;
    
    PlayerMov playerMov;
    PlayerHealth playerHealth;

    float timer;

    GameObject arm;
    GameObject gun;
    Transform gunRef;

    Transform bombRef;

    bool gunActive = false;
    public int maxAmmo = 50;
    int gunAmmo;


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

        bombRef = gameObject.transform.GetChild(2).gameObject.transform;

        gunAmmo = maxAmmo;

    }

    void FixedUpdate () {

        timer += Time.deltaTime;
        //print(timer);

        // golpear o disparar
        if (Input.GetButtonDown("P" + playerN + "F"))
        {
            timer = 0f;
            // set active arm
            if (!gunActive) arm.SetActive(true);
            else if (gunAmmo <= 0) GuardalaGun();
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

        // lanzar bomba
        //if (Input.GetButtonDown("P" + playerN + "B"))
        //{
        //    LanzaBomba();
        //}




    }

    void LanzaBomba()
    {
        GameObject instBomba = Instantiate(bomb, bombRef.position, Quaternion.identity);
        Rigidbody instBombaRigidbody = instBomba.GetComponent<Rigidbody>();


        instBombaRigidbody.AddForce(instBomba.transform.up * 10f, ForceMode.Impulse);
    }

    void DisparalaGun()
    {
        GameObject instBala = Instantiate(bala, gunRef.position, Quaternion.identity);
        Rigidbody instBalaRigidbody = instBala.GetComponent<Rigidbody>();
        Bullet instBalaScript = instBala.GetComponent<Bullet>();
        instBalaScript.SetFather(gameObject);
        Vector3 shootVec = instBala.transform.forward;
        shootVec = Quaternion.Euler(0f, gun.transform.eulerAngles.y, 0f) * shootVec;

        instBalaRigidbody.AddForce(shootVec * 20f, ForceMode.Impulse);

        gunAmmo--;

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

    void RechargeGun()
    {
        if (gunAmmo < maxAmmo)
        {
            if (gunAmmo < maxAmmo - 5)
                gunAmmo += 5;
            else while (gunAmmo < maxAmmo) gunAmmo++;

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
            playerHealth.HacerDanio(danioDeGolpe);

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "CajaBalas")
        {
            RechargeGun();
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(Respawn(other.gameObject));
        }
    }

    public bool GunIsActive()
    {
        return gunActive;
    }

    public int GetGunAmmo()
    {
        return gunAmmo;
    }

    IEnumerator Respawn(GameObject other)
    {
        yield return new WaitForSeconds(5f);
        other.GetComponent<MeshRenderer>().enabled = true;
        other.GetComponent<BoxCollider>().enabled = true;
    }

}
