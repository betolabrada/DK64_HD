using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkipVideo : MonoBehaviour {

	void FixedUpdate () {
		if(Input.GetKeyDown("joystick 1 button 0") | Input.GetKeyDown(KeyCode.Return) | Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene("MenuPrincipal");
		}
	}
}
