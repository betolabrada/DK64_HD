using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRainingDeath1 : MonoBehaviour {
    float timer;
    public float timerChido = 1f;
    private Vector3 position;
    public GameObject  ammoDrop;

    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerChido){

            position = new Vector3(Random.Range(-28.0F, 28.0F), 100, Random.Range(-20.0F, 20.0F));
            Instantiate(ammoDrop, position, Quaternion.identity);
            this.ResetTimerRainingDeath();
            
        }
    }

    public void ResetTimerRainingDeath()
    {
        timer = 0f;    
    }

}
