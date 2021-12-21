using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasCollect : MonoBehaviour
{

    public AudioSource collectSound;

    public float gasMax = 100.0f;
    private float gasDecrease = 0.2f;
    public RocketGasMeter fuelCollect;
    public int gasTotal = 100;

    void Update()
    {
        gasMax -= gasDecrease * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        scoringSystem.Instance.fuelCollected();
        Destroy(gameObject);

    }
}
