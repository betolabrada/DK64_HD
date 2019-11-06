using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalasManager : MonoBehaviour {


    public int maxAmmo = 50;
    public Text textAmmo;

    int gunAmmo;

    PlayerArm plyArm;

    bool uiActive;

	void Awake ()
    {
        plyArm = GetComponent<PlayerArm>();
        textAmmo.text = "";

        gunAmmo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update () {

        bool active = plyArm.GunIsActive();
        if (active || uiActive)
        {
            
            if (gunAmmo == 0) textAmmo.text = "¡No hay balas!";
            else textAmmo.text = "Balas: " + gunAmmo.ToString();
        }

        else
        {
            textAmmo.text = "";
        }
	}

    //public void RechargeGun(int ammo)
    //{
    //    if (gunAmmo < maxAmmo)
    //    {
    //        if (gunAmmo < maxAmmo - ammo)
    //            gunAmmo += ammo;
    //        else while (gunAmmo < maxAmmo) gunAmmo++;

    //    }

    //}

    IEnumerator RechargeGun()
    {
        print("se va aqui");
        uiActive = true;
        if (gunAmmo < maxAmmo)
        {
            for (int i = 0; i < 5 && gunAmmo < maxAmmo; i++)
            {
                gunAmmo++;
                textAmmo.text = "Balas: " + gunAmmo.ToString();
                yield return new WaitForSeconds(.25f);
            }
            yield return new WaitForSeconds(3f);
        }
        uiActive = false;

    }

    public int CurrentAmmo()
    {
        return gunAmmo;
    }

    public void Shot()
    {
        gunAmmo--;
    }
}
