using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class scoringSystem : MonoBehaviour
{
    public GameObject fuelCollect;
    //public static int currentFuel;

    public TMP_Text fuelLabel;

    public int fuelRequired;
    public int currentFuel = 0;
    public int fuelComplete;
    public GameObject youWin;

    public AudioSource victorySound;


    private static scoringSystem _instance = null;
    public static scoringSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<scoringSystem>();
            }

            return _instance;
        }
    }


    public void Start()
    {
        if (youWin != null)
        {
            youWin.SetActive(false);
        }
    }


    public void fuelUpate()
    {
        fuelLabel.SetText("FUEL ACQUIRED: " + currentFuel + "/" + fuelRequired);
    }

    public void fuelCollected()
    {
        currentFuel++;
        fuelUpate();

        if(currentFuel == fuelRequired)
        {
            Victory();
        }
    }

    public void Victory()
    {
        youWin.SetActive(true);
        victorySound.Play();
    }

}
