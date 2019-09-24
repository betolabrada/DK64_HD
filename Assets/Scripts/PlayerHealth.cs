using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int saludInicial = 10;
    public int saludActual;
    public Slider sliderSalud;


    public PlayerMov playerMov;
    bool danio;
    public bool estaMuerto;
    
    void Start()
    {
        saludActual = saludInicial;
        estaMuerto = false;
        
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

        sliderSalud.value = saludActual;

        if (saludActual <= 0 && !estaMuerto)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        estaMuerto = true;

        playerMov.enabled = false;

        Destroy(gameObject);
    }
}
