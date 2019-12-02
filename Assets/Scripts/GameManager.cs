using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	public GameObject[] Player;
	public int idP1, idP2, idP3, idP4;
	public int[] character = new int[4];
	public string[] names = {"PlayerDiddy", "PlayerDonkey", "PlayerDixie", "PlayerChunky"};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log(SceneManager.GetActiveScene().name);
		if(SceneManager.GetActiveScene().name != "Character"){
			//Debug.Log(SceneManager.GetActiveScene().name);
			for(int i = 0; i < 4; i++){
				PlayerMov actual;
				actual = GameObject.Find(names[i]).GetComponent<PlayerMov>();
				actual.playerN = character[i];
			}
		}
	}

	void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
