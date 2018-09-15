using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BombDefuse : MonoBehaviour {
    public GameObject bomb;
    public Text hint;
    string text = "Press E to defuse the bomb";
    public Text Info;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(bomb.transform.position, transform.position);
        

        if(dist<4f)
        {
            hint.text = text;
            if(Input.GetKeyDown("e")){
                print("Bomb Defused");
                text = "Bomb has been defused!";
                Health.health = 100;
                Armor.armor = 50;
                Info.text = "MISSION COMPLETE, BOMB DEFUSED!";
                Info.color = new Color(45, 181, 0); 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (hint.text == "Press E to defuse the bomb" && dist > 4f)
        {
            hint.text = "";
        }

    }
}
