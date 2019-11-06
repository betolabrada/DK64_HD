using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalasManager : MonoBehaviour {


    PlayerArm plyArm;
    int ammoP1;
    public Text textAmmo;

	void Awake ()
    {
        plyArm = GetComponent<PlayerArm>();
        textAmmo.text = "";
	}
	
	// Update is called once per frame
	void Update () {

        bool active = plyArm.GunIsActive();
        if (active)
        {
            
            if (plyArm.GetGunAmmo() == 0) textAmmo.text = "¡No hay balas!";
            else textAmmo.text = "Balas: " + plyArm.GetGunAmmo().ToString();
        }

        else
        {
            textAmmo.text = "";
        }
	}
}
