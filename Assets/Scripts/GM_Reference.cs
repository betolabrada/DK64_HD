using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_Reference : MonoBehaviour {

	GameManager mivarGame;
	// Use this for initialization
	void Start () {
		mivarGame = GameObject.Find("GameManager").GetComponent<GameManager>();	
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
