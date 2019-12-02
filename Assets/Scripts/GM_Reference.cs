using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_Reference : MonoBehaviour {

	GameManager mivarGame;
	public GameObject btnPlay;
	public int[] characters = new int[4];
	int idP1, idP2, idP3, idP4;
	// Use this for initialization
	void Start () {
		mivarGame = GameObject.Find("GameManager").GetComponent<GameManager>();	
		characters[0] = 0;
		characters[1] = 0;
		characters[2] = 0;
		characters[3] = 0;
	}
	public bool SelectCharacter(int num, int player){
		if(characters[num] != 0){
			return false;
		}else{
			characters[num] = player;
			return true;
		}
		
	}

	public void DeselectCharacter(int num){
		characters[num] = 0;
	}
	// Update is called once per frame
	void Update () {
		if(characters[0] !=0 && characters[1] != 0 && characters[2] != 0 && characters[3] !=0){
			btnPlay.SetActive(true);
			mivarGame.character[0] = characters[0];
			mivarGame.character[1] = characters[1];
			mivarGame.character[2] = characters[2];
			mivarGame.character[3] = characters[3];
		}else{
			btnPlay.SetActive(false);
		}
	}
}
