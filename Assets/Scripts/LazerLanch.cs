using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerLanch : MonoBehaviour
{

    public GameObject projectile;
    public float launchVelocity = 100f;
    private float currLifeTime = 0;
  



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currLifeTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            transform.Translate(0, 0, Time.deltaTime);
            GameObject lazer = Instantiate(projectile, transform.position, transform.rotation);
            // transform.Translate(Vector3.forward * Time.deltaTime);
            lazer.GetComponent<Rigidbody>().AddForce(Vector3.forward * launchVelocity);

        }

    }


}


   