using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public void CambiarEscena(){
		SceneManager.LoadScene("SampleScene");
	}

	public void SalirJuego(){
		Debug.Log("uihdsuf");
		//Application.Quit();
	}
}
