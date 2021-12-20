using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{

    public Transform target;

    public Transform spawnPoint;

    public GameObject lazerPrefab;

    private float currDelayTime = 0;

    public float firingRange;
    public float firingDelay;

    public float rotationSpeed;
    public GameObject mainPoint;

    public Transform player;

    public GameObject projectile;
    public float launchVelocity = 100f;

    public AudioSource lazerShot;

    // Start is called before the first frame update
    void Start()
    {
        rotateObject();

        GameObject findPlayer = GameObject.FindWithTag("Player");

        if (findPlayer != null)
        {
            player = findPlayer.transform;
        }

        player = GameObject.FindWithTag("Player").transform;
       

    }

    // Update is called once per frame
    void Update()
    {
        currDelayTime += Time.deltaTime;
      //  attackPlayer(); 


        if (Vector3.Distance(transform.position, target.position) < firingRange)
        {
            seePlayer();
            attackPlayer();

            if (currDelayTime > firingDelay)
            {
                Shoot();
                currDelayTime = 0;
            }
        }
        else
        {
          // rotateObject();

        }


    }

    public void seePlayer()
    {
        transform.LookAt(target);
    }

    public void Shoot()
    {
        attackPlayer();
       // makeLasers();
        lazerShot.Play();
       Instantiate(lazerPrefab, spawnPoint.position, spawnPoint.rotation);
    }


    public void attackPlayer()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
    }

    public void rotateObject()
    {
        transform.RotateAround(mainPoint.transform.position, Vector3.up, 20 * Time.deltaTime);
    }

 /*   public void makeLasers()
    {
        transform.Translate(0, 0, Time.deltaTime);
        GameObject lazer = Instantiate(projectile, transform.position, transform.rotation);
        transform.Translate(Vector3.forward * Time.deltaTime);
        lazer.GetComponent<Rigidbody>().AddForce(Vector3.forward * launchVelocity);
    }
 */
}
