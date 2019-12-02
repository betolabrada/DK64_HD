using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour {
	public GameObject modos ,este;
	public GameObject grupo1, grupo2;
	public GameObject nextBtn;
	private int grupoActual;
	public int modo;
	GameManager gm;
	void Start(){
		grupoActual = 1;
	}
	public void CambiarEscena(){
		SceneManager.LoadScene("SelectMode");
		
	}

	public void Characters(){
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		gm.modoActual = modo;
		SceneManager.LoadScene("Character");
			
		
	}

	public void CambiarModo(){
		modos.SetActive(true);
		este.SetActive(false);
	}
	
	public void NextGroup(){
		grupo1.SetActive(false);
		grupo2.SetActive(true);
		this.gameObject.SetActive(false);
		
	}

	public void BackGroup(){
		grupo2.SetActive(false);
		grupo1.SetActive(true);
		nextBtn.SetActive(true);
	}

	public void ModoDummy(){
		SceneManager.LoadScene("SampleScene");
	}

	public void ReiniciarEscena(){
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		SceneManager.LoadScene("Loading");
		//gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		//gm.asignado = false;
	}

	public void MainMenu(){
		SceneManager.LoadScene("MenuPrincipal");
		
	}

	public void PlayGame(){
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		SceneManager.LoadScene(gm.modoActual);
	}

	public void SalirJuego(){
		Debug.Log("uihdsuf");
		Application.Quit();
	}
}
