using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class Enemy : MonoBehaviour
{

    public GameObject enemy;
    public Transform playerPos;
    public Transform currentPos;
    public Light light;
    public float enemyHealth = 100;
    public FirstPersonController fPlayer;

    int raycastCounter = 20;
    // Update is called once per frame
    void Update(){
        light.intensity = 0;
        transform.LookAt(playerPos.position * 2 - currentPos.position, Vector3.up);
        currentPos.transform.Rotate(0, 270, 0);

        Ray ray = new Ray(transform.position + new Vector3(0,1,0), transform.right);
        Debug.DrawRay(transform.position + new Vector3(0,1,0), transform.right, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.gameObject.name.Equals("Player"))
            {
                print(hit.collider.gameObject.name);
                raycastCounter++;

                if (raycastCounter == 75)
                {
                    shoot();
                    raycastCounter = 0;
                }
            }

        }

    }
    
    public void damageEnemy(float damage){
        enemyHealth = enemyHealth - damage;
        print("Damaged enemy by " + damage + " damage");
        if(enemyHealth < 1){
            Destroy(this.gameObject);
        }
    }

    public void shoot(){
        light.intensity = 3;
        GetComponent<AudioSource>().Play();
        
        float distance = Vector3.Distance(currentPos.transform.position, playerPos.transform.position);
        if(distance < 7){
            if (fPlayer.getArmour() > 0){
                fPlayer.setArmour(-32f);
            }else{
                fPlayer.setHealth(-38f);
            }
        }
        else if(distance > 7 && distance < 12){
            if (fPlayer.getArmour() > 0){
                fPlayer.setArmour(-28f);
            }else{
                fPlayer.setHealth(-34f);
            }        }
        else if(distance>12 && distance < 16){
            if (fPlayer.getArmour() > 0){
                fPlayer.setArmour(-25f);
            }else{
                fPlayer.setHealth(-28f);
            }
        }
        else if(distance > 16 ){
            if (fPlayer.getArmour() > 0){
                fPlayer.setArmour(-18f);
            }else{
                fPlayer.setHealth(-23f);
            }
        }
        
    }

}
