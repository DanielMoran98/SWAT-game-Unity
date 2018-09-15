using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLightBlink : MonoBehaviour {
    public Light light;
    int counter = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        light.intensity = 0;
        counter++;
        if(counter%40<15)
        {
            light.intensity = 3;
        }
    }
}
