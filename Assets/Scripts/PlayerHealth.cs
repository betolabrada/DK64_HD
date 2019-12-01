using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int saludInicial = 10;
    public int saludActual;
    public Slider sliderSalud;
    public int recuperacion = 2;
    public float tiempoSinDanio = 3f;
    public Color colorDanio = new Color(1f, 0f, 0f, 0.1f);
    public float flashSpeed = 5f;
    public Animator animator;
    PlayersAlive playersAlive;
    float timer;
    PlayerMov playerMov;
    bool danio;
    public bool estaMuerto;
    AudioSource playerAudio;
    bool hayCoroutine = false;
    MeshRenderer materialRenderer;
    Color playerOriginalColor;
    
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        saludActual = saludInicial;
        estaMuerto = false;
        playersAlive = GameObject.Find("World").GetComponent<PlayersAlive>();
        playerMov = GetComponent<PlayerMov>();
        materialRenderer = GetComponent<MeshRenderer>();
        playerOriginalColor = materialRenderer.material.color;
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
            materialRenderer.material.color = colorDanio;
        }

        else
        {
            materialRenderer.material.color = Color.Lerp(materialRenderer.material.color, playerOriginalColor, 
                flashSpeed * Time.deltaTime);

        }
        if (gameObject.layer == 14)
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

    public void RecuperarVida(int vida)
    {
        for (int i = 0; i < vida && saludActual < saludInicial; i++)
        {
            saludActual += vida;
            sliderSalud.value = saludActual;
        }
        
    }

    void Muerte()
    {
        animator.SetBool("IsDead", true);
        estaMuerto = true;
        playerMov.enabled = false;
        playersAlive.DecreseCount();
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
