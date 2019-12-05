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
    public bool fin = false;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)  | Input.GetKeyDown("joystick 1 button 7") | Input.GetKeyDown("joystick 2 button 7") | Input.GetKeyDown("joystick 3 button 7") | Input.GetKeyDown("joystick 4 button 7")){
            SceneManager.LoadScene("MenuPrincipal");
        }
        if (SceneManager.GetActiveScene().name != "Character")
        {
            if (SceneManager.GetActiveScene().name == "MenuPrincipal")
            {
				//asignado = false;
            }
            else
            {
                
                //StartCoroutine(Reiniciando());
                if (asignado == false)
                {
                    if(SceneManager.GetActiveScene().name == "Loading"){
                    
                    }else
                    {
                        Time.timeScale = 0;

                        for (int i = 0; i < 4; i++)
                        {
                            PlayerMov actual = null;
                            actual = GameObject.Find(names[i]).GetComponent<PlayerMov>();
                            Debug.Log(actual);
                            actual.playerN = character[i];
                        }
                        asignado = true;
                        Time.timeScale = 1;
                    }
					
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
	
    IEnumerator Reiniciando(){
        yield return new WaitForSeconds(3);
    }
}
