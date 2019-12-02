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

	public GameObject winPanel;
	public Text winText;
	// Use this for initialization
	void Start () {
		alive = 4;
<<<<<<< HEAD
		P1 =  GameObject.Find("Player1").GetComponent<PlayerHealth>();
		P2 =  GameObject.Find("Player2").GetComponent<PlayerHealth>();
		P3 =  GameObject.Find("Player3").GetComponent<PlayerHealth>();
		P4 =  GameObject.Find("Player4").GetComponent<PlayerHealth>();

        P1Hill = GameObject.Find("Player1").GetComponent<PlayerMov>();
        P2Hill = GameObject.Find("Player2").GetComponent<PlayerMov>();
        P3Hill = GameObject.Find("Player3").GetComponent<PlayerMov>();
        P4Hill = GameObject.Find("Player4").GetComponent<PlayerMov>();
=======
		P1 =  GameObject.Find("PlayerDonkey").GetComponent<PlayerHealth>();
		P2 =  GameObject.Find("PlayerDiddy").GetComponent<PlayerHealth>();
		P3 =  GameObject.Find("PlayerDixie").GetComponent<PlayerHealth>();
		P4 =  GameObject.Find("PlayerChunky").GetComponent<PlayerHealth>();

        P1Hill = GameObject.Find("PlayerDonkey").GetComponent<PlayerMov>();
        P2Hill = GameObject.Find("PlayerDiddy").GetComponent<PlayerMov>();
        P3Hill = GameObject.Find("PlayerDixie").GetComponent<PlayerMov>();
        P4Hill = GameObject.Find("PlayerChunky").GetComponent<PlayerMov>();
>>>>>>> df1051a49a2dd24f5ce1fc90f7cc5050b8a79117

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

        if (P1Hill.hillPoints > 200)
        {
            ganador = "DONKEY";
            //print("GANASTE JUGADOR " + ganador);
            winPanel.SetActive(true);
            winText.text = ("GANASTE JUGADOR " + ganador);
            //Time.timeScale = 0;
        }

        if (P2Hill.hillPoints > 200)
        {
            ganador = "DIDDY";
            //print("GANASTE JUGADOR " + ganador);
            winPanel.SetActive(true);
            winText.text = ("GANASTE JUGADOR " + ganador);
            //Time.timeScale = 0;
        }

        if (P3Hill.hillPoints > 200)
        {
            ganador = "DIXIE";
            //print("GANASTE JUGADOR " + ganador);
            winPanel.SetActive(true);
            winText.text = ("GANASTE JUGADOR " + ganador);
            //Time.timeScale = 0;
        }

        if (P4Hill.hillPoints > 200)
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
