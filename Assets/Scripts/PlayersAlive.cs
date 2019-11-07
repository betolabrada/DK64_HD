using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayersAlive : MonoBehaviour {

	private int alive;
	PlayerHealth P1, P2, P3, P4;
	private int ganador;

	public GameObject winPanel;
	public Text winText;
	// Use this for initialization
	void Start () {
		alive = 4;
		P1 =  GameObject.Find("Player").GetComponent<PlayerHealth>();
		P2 =  GameObject.Find("Player2").GetComponent<PlayerHealth>();
		P3 =  GameObject.Find("Player3").GetComponent<PlayerHealth>();
		P4 =  GameObject.Find("Player4").GetComponent<PlayerHealth>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(alive == 1){
			if(!P1.estaMuerto){
				ganador = 1;
			} else if(!P2.estaMuerto){
				ganador = 2;
			} else if(!P3.estaMuerto){
				ganador = 3;
			} else if(!P4.estaMuerto){
				ganador = 4;
			}
			//print("GANASTE JUGADOR " + ganador);
			winPanel.SetActive(true);
			winText.text = ("GANASTE JUGADOR " + ganador);
			Time.timeScale = 0;
		}
	}

	public void DecreseCount(){
		alive--;
		print(alive);
	}
}
