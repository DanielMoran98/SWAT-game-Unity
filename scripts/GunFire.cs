using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GunFire : MonoBehaviour {
    public Animation anim;
    public Light light;
    public GameObject ar;
    public GameObject shotgun;
    public GameObject handgun;
    public GameObject sniper;
    public AudioClip clip;
    public AudioClip empty;
    public AudioClip reload;
    public Text text;
    public Text hint;
    public int ammo;
    int counter;
    float timer = 0;
    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        light.intensity = 0;
        counter = 0;
        ammo = 20;
    }
	
	// Update is called once per frame
	void Update () {
        //Ray ray = new Ray(transform.position + new Vector3(0, 0.15f, 0), transform.forward);
        Debug.DrawRay(transform.position + new Vector3(0, 0.15f, 0), transform.forward*1000,Color.red,1, false);
        Physics.Raycast(transform.position + new Vector3(0, 0.15f, 0), transform.forward, out hit);


        light.intensity = 0;
        text.text = ammo.ToString();
        timer = timer + Time.deltaTime;
        
        if (ammo==0)
        {
            hint.text = "Press R to reload.";
        }

        

        if (ammo > 0)
        {
            if (!hint.text.Equals("Press E to defuse the bomb") && !hint.text.Equals("Bomb has been defused!"))
            {
                hint.text = "";
            }
            
            if (Input.GetMouseButtonDown(0)) //Semi-Auto
            {
                playSemi();
            }

            if (ar.active)  //For full auto
            {
                if (Input.GetMouseButton(0) && counter % 5 == 0)
                {
                    playAuto();

                }
                counter++;
            }
        }
        else if(ammo == 0)
        {
            if (Input.GetMouseButtonDown(0)) //Semi-Auto
            {
                GetComponent<AudioSource>().PlayOneShot(empty);
                counter++;
            }
            
        }

        if (Input.GetKeyDown("r"))
        {
           
            reloadgun();
        }

}
        

    public void playAuto()
    {
        GetComponent<Animation>().Play();
        GetComponent<AudioSource>().PlayOneShot(clip);
        light.intensity = 3;
        ammo--;

        if (hit.collider.tag == "enemy")
        {   
            

            if(ar.active)
            {
                hit.collider.gameObject.GetComponent<Enemy>().damageEnemy(20);
                print("ENEMY DAMAGED BY AR: 20 DAMAGE");
            }
        }
        else if (hit.collider.tag == "innocent")
        {
            SceneManager.LoadScene(3);
        }




    }

    public void playSemi()
    {
        GetComponent<Animation>().Play();
        GetComponent<AudioSource>().Play();
        light.intensity = 3;
        ammo--;

        if (hit.collider.tag == "enemy")
        {

             if (handgun.gameObject.activeSelf)
             {
                    hit.collider.gameObject.GetComponent<Enemy>().damageEnemy(15);
                    print("ENEMY DAMAGED BY HANDGUN: 15 DAMAGE");
             }
            

             if (shotgun.gameObject.activeSelf)
             {
                 hit.collider.gameObject.GetComponent<Enemy>().damageEnemy(40);
                 print("ENEMY DAMAGED BY SHOTGUN: 40 DAMAGE");
             }
               

                
            if (sniper.gameObject.activeSelf)
            {
                 hit.collider.gameObject.GetComponent<Enemy>().damageEnemy(100);
                 print("ENEMY DAMAGED BY SNIPER: 100 DAMAGE");
            }
                

            
        }
        else if(hit.collider.tag == "innocent")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public void reloadgun()
    {
        
        GetComponent<AudioSource>().PlayOneShot(reload);
        
        ammo = 20;
    }
}