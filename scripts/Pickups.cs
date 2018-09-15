using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Pickups : MonoBehaviour{

    public FirstPersonController rPlayer;
    
    public float fHealth;
    public float fAmour;

    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        rPlayer.setHealth(fHealth);
        rPlayer.setArmour(fAmour);
    }
}
