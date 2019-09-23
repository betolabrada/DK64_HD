using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int saludInicial = 10;
    public int saludActual;

    PlayerMov playerMov;
    bool danio;
    bool estaMuerto;
    
    void Start()
    {
        saludActual = saludInicial;
    }

    void Update()
    {
        if (danio)
        {
            // script de sandias
        }
        danio = false;
    }
    public void HacerDanio(int cantidad)
    {
        danio = true;
        saludActual -= cantidad;

        if (saludActual <= 0 && !estaMuerto)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        estaMuerto = true;

        playerMov.enabled = false; 
    }
}
