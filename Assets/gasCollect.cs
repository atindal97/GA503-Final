using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasCollect : MonoBehaviour
{

    public AudioSource collectSound;

    public void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        scoringSystem.Instance.fuelCollected();
        Destroy(gameObject);

    }
}
