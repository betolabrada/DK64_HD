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
	void Start(){
		grupoActual = 1;
	}
	public void CambiarEscena(){
		SceneManager.LoadScene("SelectMode");
		
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
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu(){
		SceneManager.LoadScene("MenuPrincipal");
		
	}

	public void SalirJuego(){
		Debug.Log("uihdsuf");
		//Application.Quit();
	}
}
