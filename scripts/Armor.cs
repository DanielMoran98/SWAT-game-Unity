using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armor : MonoBehaviour
{
    public Text armorbar;
    public static float armor = 50;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (armor > 100)
        {
            armor = 100;
        }
        if (armor < 0)
        {
            armor = 0;
        }

        armorbar.rectTransform.sizeDelta = new Vector2(armor * 2.5f, 35);

    }

    public static void damage(float damage)
    {
        float newArmor = armor - damage;
        if(newArmor < 1)
        {
            Health.removeHealth(newArmor * -1f);
        }
        armor = newArmor;
        newArmor = 0;
        
    }

    public static void giveArmor(float addarmor)
    {
        armor = armor + addarmor;
        
    }
}
