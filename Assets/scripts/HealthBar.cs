using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // start is called before the first frame update
    public static HealthBar instance;
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
 
    

    void Start()
    {
        health = maxHealth;
        instance = this;
    }

     //update is called once per frame
    void Update()
    {
      if(healthSlider.value != health)
      {
            healthSlider.value = health;
      }

      if (Input.GetKeyDown(KeyCode.Space))
      {
            
            takeDamage(35);
      }
    
      
    }

    public static void takeDamage(float damage)
    {
       instance.health -= damage;
    }
}
