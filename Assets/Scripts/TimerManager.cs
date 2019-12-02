using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    public float duration = 180f;
    public Text timerLeft;

    void Start ()
    {
        StartCoroutine("Seconds");
    }

    IEnumerator Seconds()
    {
        while (duration >= 0)
        {
            timerLeft.text = "" + TimeSpan.FromSeconds(duration);
            duration--;
            yield return new WaitForSeconds(1f);
        }
    }


}
