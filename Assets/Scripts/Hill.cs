using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hill : MonoBehaviour {
    private Rigidbody rb;
    public bool playerOnHill;
    public int playersOnHill;
    private float timerChido = 8f;
    private Vector3 randomPosition;
    float timer;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        this.playerOnHill = false;
        this.playersOnHill = 0;

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timerChido){
            randomPosition = new Vector3(Random.Range(-26.0F, 26.0F), 0.6f, Random.Range(-16.0F, 19.0F));
            transform.position = randomPosition;
            this.ResetTimerRainingDeath();
        }
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == ("Player")){
            this.playerOnHill = true;
            this.playersOnHill++;
            print(playersOnHill);
        }
    }

    void OnCollisionExit(Collision collision){
        if (collision.gameObject.tag == ("Player")){
            this.playersOnHill--;
        }
    }

    public void ResetTimerRainingDeath()
    {
        timer = 0f;
        if (timerChido != .1f)
        {
            timerChido -= .1f;
        }

    }
}
