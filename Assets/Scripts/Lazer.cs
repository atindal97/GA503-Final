using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float firingRange;
    public float firingDelay;
    public Transform rocket;

    public Transform spawnPoint;
    public Lazer prefab;

    private float currDelayTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGo = GameObject.FindWithTag("Player");

        if (playerGo != null)
        {
            rocket = playerGo.transform;
        }

        rocket = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currDelayTime += Time.deltaTime;

        if (Vector3.Distance(transform.position, rocket.position) < firingRange)
        {
            AimAtPlayer();

            if (currDelayTime > firingDelay)
            {
                Shoot();
                currDelayTime = 0;
            }
        }
    }

    public void AimAtPlayer()
    {
        transform.LookAt(rocket);
    }

    public void Shoot()
    {
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
