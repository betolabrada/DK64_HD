using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaChidaEnMapa : MonoBehaviour {

    public GameObject armaChida;
    public Transform[] refs;

    float timer;
    bool toggler = false;

    public bool armaChidaStillThere = false;

    GameObject instArmaChida;

    void Update () {
        timer += Time.deltaTime;
        if (timer >= 10f)
        {
            if (!armaChidaStillThere)
            {
                if (toggler) instArmaChida = Instantiate(armaChida, refs[0].position, Quaternion.identity);
                else instArmaChida = Instantiate(armaChida, refs[1].position, Quaternion.identity);
                toggler = !toggler;
                armaChidaStillThere = true;
            }
        }
    }

    public void ResetTimerArmaRespawn()
    {
        timer = 0f;
    }
      

}
