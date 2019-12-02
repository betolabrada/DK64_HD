using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCharacter : MonoBehaviour
{

    Image Player;
    public Sprite[] characters = new Sprite[4];
    int actualChar = 0;
    public AudioSource sonidito;
    public GameObject Selected_Image;
    bool Selected;
    public int playerN;
	public AudioClip change, cancel;
    GM_Reference gmReference;
    void Start()
    {
        Selected = false;
        Player = GetComponent<Image>();
        Player.sprite = characters[actualChar];
        sonidito = GetComponent<AudioSource>();
        gmReference = GameObject.Find("Reference").GetComponent<GM_Reference>();
    }

    // Update is called once per frame
    void Update()
    {

        //	SELECCIONAR PERSONAJE
        if (Input.GetKeyDown("joystick " + playerN + " button 0"))
        {
            if (gmReference.SelectCharacter(actualChar, playerN))
            {
                if (Selected == false)
                {
                    Selected = true;
                    sonidito.Play();
                }
            }else{
                sonidito.PlayOneShot(cancel);
            }

        }

        //	DESELECCIONAR PERSONAJE
        if (Input.GetKeyDown("joystick " + playerN + " button 1"))
        {
            Selected = false;
            gmReference.DeselectCharacter(actualChar);
            sonidito.PlayOneShot(cancel);
        }

        if (Selected)
        {
            Selected_Image.SetActive(true);
        }
        else
        {
            Selected_Image.SetActive(false);
            //	CAMBIAR PERSONAJE
            if (Input.GetKeyDown("joystick " + playerN + " button 5"))
            {
                actualChar++;
                if (actualChar == characters.Length)
                {
                    actualChar = 0;
                }
                //Debug.Log(actualChar);
				sonidito.PlayOneShot(change);
                Player.sprite = characters[actualChar];
            }

            if (Input.GetKeyDown("joystick " + playerN + " button 4"))
            {
                actualChar--;
                if (actualChar == -1)
                {
                    actualChar = characters.Length - 1;
                }
                sonidito.PlayOneShot(change);
                Player.sprite = characters[actualChar];
            }

        }
    }
}
