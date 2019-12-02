using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	public GameObject[] Player;
	public int idP1, idP2, idP3, idP4;
	public int[] character = new int[4];
	public string[] names = {"PlayerDiddy", "PlayerDonkey", "PlayerDixie", "PlayerChunky"};
	public int modoActual;
	public bool asignado = false;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Character")
        {
            if (SceneManager.GetActiveScene().name == "MenuPrincipal")
            {
				asignado = false;
            }
            else
            {
                if (asignado == false)
                {
					Time.timeScale = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        PlayerMov actual;
                        actual = GameObject.Find(names[i]).GetComponent<PlayerMov>();
                        actual.playerN = character[i];
                    }
					asignado = true;
					Time.timeScale = 1;
                }

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
