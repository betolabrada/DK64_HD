using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayersAlive : MonoBehaviour {

	private int alive;
	PlayerHealth P1, P2, P3, P4;
    PlayerMov P1Hill, P2Hill, P3Hill, P4Hill;
    private string ganador;
    public GameObject gameManagerObject;
    GameManager gameManager;

    public GameObject winPanel;
	public Text winText;
	// Use this for initialization
	void Start () {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        alive = 4;
		P1 =  GameObject.Find("PlayerDonkey").GetComponent<PlayerHealth>();
		P2 =  GameObject.Find("PlayerDiddy").GetComponent<PlayerHealth>();
		P3 =  GameObject.Find("PlayerDixie").GetComponent<PlayerHealth>();
		P4 =  GameObject.Find("PlayerChunky").GetComponent<PlayerHealth>();

        P1Hill = GameObject.Find("PlayerDonkey").GetComponent<PlayerMov>();
        P2Hill = GameObject.Find("PlayerDiddy").GetComponent<PlayerMov>();
        P3Hill = GameObject.Find("PlayerDixie").GetComponent<PlayerMov>();
        P4Hill = GameObject.Find("PlayerChunky").GetComponent<PlayerMov>();

    }

	// Update is called once per frame
	void Update () {

		if(alive == 1){
			if(!P1.estaMuerto){
				ganador = "DONKEY";
			} else if(!P2.estaMuerto){
				ganador = "DIDDY";
			} else if(!P3.estaMuerto){
				ganador = "DIXIE";
			} else if(!P4.estaMuerto){
				ganador = "CHUNKY";
			}
			//print("GANASTE JUGADOR " + ganador);
			winPanel.SetActive(true);
			winText.text = ("GANASTE " + ganador);
			//Time.timeScale = 0;
		}

        if (alive == 2 && gameManager.modoActual == 9 || alive == 1 && gameManager.modoActual == 9)
        {
            if (P3.estaMuerto && P4.estaMuerto)
            {
                ganador = "DONKEY y DIDDY";
            }
            else if (P1.estaMuerto && P2.estaMuerto)
            {
                ganador = "CHUNKY Y DIXIE";
            }
            //print("GANASTE JUGADOR " + ganador);
            winPanel.SetActive(true);
            winText.text = ("GANASTE " + ganador);
            //Time.timeScale = 0;
        }

        if (P1Hill.hillPoints > 100)
        {
            ganador = "DONKEY";
            //print("GANASTE JUGADOR " + ganador);
            winPanel.SetActive(true);
            winText.text = ("GANASTE JUGADOR " + ganador);
            //Time.timeScale = 0;
        }

        if (P2Hill.hillPoints > 100)
        {
            ganador = "DIDDY";
            //print("GANASTE JUGADOR " + ganador);
            winPanel.SetActive(true);
            winText.text = ("GANASTE JUGADOR " + ganador);
            //Time.timeScale = 0;
        }

        if (P3Hill.hillPoints > 100)
        {
            ganador = "DIXIE";
            //print("GANASTE JUGADOR " + ganador);
            winPanel.SetActive(true);
            winText.text = ("GANASTE JUGADOR " + ganador);
            //Time.timeScale = 0;
        }

        if (P4Hill.hillPoints > 100)
        {
            ganador = "CHUNKY";
            //print("GANASTE JUGADOR " + ganador);
            winPanel.SetActive(true);
            winText.text = ("GANASTE JUGADOR " + ganador);
            //Time.timeScale = 0;
        }


    }

	public void DecreseCount(){
		alive--;
		print(alive);
	}
}
