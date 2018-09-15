using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScope : MonoBehaviour
{

    int toggle = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (toggle == 0)
            {
                Camera.main.fieldOfView = 20;
                toggle++;
            }
            else if (toggle == 1)
            {
                Camera.main.fieldOfView = 60;
                toggle--;
            }

        }
    }
}
