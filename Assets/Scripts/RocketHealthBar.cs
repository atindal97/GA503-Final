using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketHealthBar : MonoBehaviour
{

    public Slider healthBar;
    public RocketHealth playerHealth;

    private void Start()
    {
        
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<RocketHealth>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
        
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
