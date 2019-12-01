using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRainingDeath : MonoBehaviour {
    float timer;
    public float timerChido = 2.5f;
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
        if (timerChido !=  .1f){
            timerChido -= .1f;
        }
      
    }

}
