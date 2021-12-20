using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerCollide : MonoBehaviour
{

    public GameObject projectile;

    public float flightspeed;
    public float lifetime;

    public float currLifeTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  void Update()
    {
        
        currLifeTime += Time.deltaTime;

        transform.Translate(Vector3.forward * flightspeed * Time.deltaTime);

        if (currLifeTime > lifetime)
        {
            Destroy(gameObject);
        }
        
    }
  

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided with player");
        if (other.collider.gameObject.CompareTag("Player"))
        {
            RocketHealth e = other.gameObject.GetComponent<RocketHealth>();
            ContactPoint contact = other.contacts[0];
            Vector3 point = contact.point;

            if (e != null)
            {
                e.DamagePlayer(3);
            }
            
          Destroy(gameObject);
        }
        
    }
}
