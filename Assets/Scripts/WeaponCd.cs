using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCd : MonoBehaviour {
    private float timeStamp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 10 seg de cooldown del arma chida
        timeStamp = Time.time + 10;
        if (timeStamp <= Time.time){
            //clonar objeto
        }
    }
}
