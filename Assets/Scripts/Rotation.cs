using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	void Update()
    {
        transform.Translate(new Vector3(-0.25f, 0f, 0.25f) * Time.deltaTime);
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }
}
