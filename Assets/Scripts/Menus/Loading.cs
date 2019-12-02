using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		StartCoroutine(Reiniciando());
		//Debug.Log("Asd");
		gameManager.asignado = false;
		SceneManager.LoadScene(gameManager.modoActual);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 IEnumerator Reiniciando(){
        yield return new WaitForSeconds(1.0f);
    }
}
