using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Text healthbar;
    public static float health = 100;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
        healthbar.rectTransform.sizeDelta = new Vector2(health*2.5f ,35);
        if (health<1)
        {
            SceneManager.LoadScene(3);
            try
            {
                SceneManager.UnloadSceneAsync(4);
                print("Unloaded Scene 4");
            }
            catch (System.Exception e) { }
            try
            {
                SceneManager.UnloadSceneAsync(5);
                print("Unloaded Scene 5");
            }
            catch (System.Exception e) { }
            try
            {
                SceneManager.UnloadSceneAsync(6);
                print("Unloaded Scene 6");
            }
            catch (System.Exception e) { }
            try
            {
                SceneManager.UnloadSceneAsync(7);
                print("Unloaded Scene 7");
            }
            catch (System.Exception e) { }

            health = 100;
            Armor.giveArmor(50);
            
            
            
        }
    }

    public static void removeHealth(float damage)
    {
        health = health - damage;
    }

    public static void giveHealth(float addhealth)
    {
        health = health + addhealth;
        if(health>100)
        {
            health = 100;
        }
    }
}
