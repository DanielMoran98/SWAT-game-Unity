using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour {
    public GameObject ar;
    public GameObject shotgun;
    public GameObject handgun;
    public GameObject sniper;

    // Use this for initialization
    void Start () {
        ar.SetActive(true);
        shotgun.SetActive(false);
        handgun.SetActive(false);
        sniper.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1"))
        {
            ar.SetActive(true);
            shotgun.SetActive(false);
            handgun.SetActive(false);
            sniper.SetActive(false);
        }


        if (Input.GetKeyDown("2"))
        {
            ar.SetActive(false);
            shotgun.SetActive(true);
            handgun.SetActive(false);
            sniper.SetActive(false);
        }

        if (Input.GetKeyDown("3"))
        {
            ar.SetActive(false);
            shotgun.SetActive(false);
            handgun.SetActive(true);
            sniper.SetActive(false);
        }

        if (Input.GetKeyDown("4"))
        {
            ar.SetActive(false);
            shotgun.SetActive(false);
            handgun.SetActive(false);
            sniper.SetActive(true);
        }

    }
}
