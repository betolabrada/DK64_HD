using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int saludInicial = 10;
    public int saludActual;
    public Slider sliderSalud;
    public int recuperacion = 2;
    public float tiempoSinDanio = 3f;

    float timer;
    PlayerMov playerMov;
    bool danio;
    public bool estaMuerto;
    AudioSource playerAudio;
    bool hayCoroutine = false;
    
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        saludActual = saludInicial;
        estaMuerto = false;

        playerMov = GetComponent<PlayerMov>();        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (danio)
        {
            // script de sandias
            timer = 0f;
            StopCoroutine("Recuperacion");
            hayCoroutine = false;
        }
        if(gameObject.layer == 14)
        {
            if (saludActual < saludInicial && timer > tiempoSinDanio && !hayCoroutine)
            {
                hayCoroutine = true;
                print("coroutine");
                StartCoroutine("Recuperacion");
            }
        }
       
        danio = false;
    }
    public void HacerDanio(int cantidad)
    {
        danio = true;
        saludActual -= cantidad;
        sliderSalud.value = saludActual;
        playerAudio.Play();    
        if (saludActual <= 0 && !estaMuerto){
            Muerte();
        }
    }

    void Muerte()
    {
        estaMuerto = true;
        playerMov.enabled = false;
        Destroy(gameObject);
    }

    IEnumerator Recuperacion() 
    {

        print("se va aqui");
        while (saludActual < saludInicial){
            saludActual += recuperacion;
            sliderSalud.value = saludActual;
            print("recup");
            yield return new WaitForSeconds(1f);
        }

        print("vida llena");
        hayCoroutine = false;
       
    }
}
