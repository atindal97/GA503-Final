using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketHealth : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 10;
    public float checkHealth = 0;
    public bool playerDeath = false;

    public AudioSource collectSound;

    public RocketHealthBar healthBar;

    void Start()
    {

       // healthBar.SetHealth(curHealth);
        curHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {

        
        curHealth -= damage;

        healthBar.SetHealth(curHealth);


        if (curHealth > 0)
        {
            playerDeath = false;
        }
        else
        {
            playerDeath = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }


    }

 public void OnCollisionEnter(Collision other)
    {
       // Debug.Log("collided with enemy");
        if (other.collider.gameObject.CompareTag("Enemy"))
        {
           RocketHealth e = other.gameObject.GetComponent<RocketHealth>();
            ContactPoint contact = other.contacts[0];
            Vector3 position = contact.point;
            DamagePlayer(10);
        }

        if (other.collider.gameObject.CompareTag("Collect"))
        {
            ContactPoint contact = other.contacts[0];
            Vector3 position = contact.point;
            collectSound.Play();
            scoringSystem.Instance.fuelCollected();
            Destroy(gameObject);
           
        }
    }
 

}
