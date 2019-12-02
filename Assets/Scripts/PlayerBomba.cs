using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomba : MonoBehaviour {

    public GameObject bomba;
    public Transform bombRef;
    public GameObject gameManagerObject;

    GameManager gameManager;
    int playerN;

    void Awake ()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        playerN = GetComponent<PlayerMov>().playerN;

    }

    void Update ()
    {
        if ((Input.GetButtonDown("P" + playerN + "B") && gameManager.modoActual != 8 && gameManager.modoActual != 7))
        {
            GameObject inst = Instantiate(bomba, bombRef.position, bombRef.rotation);
            Physics.IgnoreCollision(inst.GetComponent<Collider>(), GetComponent<Collider>());
            
        }
    }


}
