using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayersAlive : MonoBehaviour {

	private int alive;
	PlayerHealth P1, P2, P3, P4;
	private string ganador;

	public GameObject winPanel;
	public Text winText;
	// Use this for initialization
	void Start () {
		alive = 4;
		P1 =  GameObject.Find("PlayerDonkey").GetComponent<PlayerHealth>();
		P2 =  GameObject.Find("PlayerDiddy").GetComponent<PlayerHealth>();
		P3 =  GameObject.Find("PlayerDixie").GetComponent<PlayerHealth>();
		P4 =  GameObject.Find("PlayerChunky").GetComponent<PlayerHealth>();
		
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
	}

	public void DecreseCount(){
		alive--;
		print(alive);
	}
}
