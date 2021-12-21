using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class TitleBegin : MonoBehaviour
{

    public GameObject menu = null;
    public GameObject optionsUI = null;
    public GameObject returnbuttonUI = null;
    public GameObject returnButton = null;

    public GameObject optionsButton =null;
    public GameObject playButton = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickPlay()
    {
        SceneManager.LoadScene("Rocket");
    }

    public void clickOptions()
    {
    
            optionsUI.SetActive(true);  
    }
    
    public void returnOptions()
    {
            optionsUI.SetActive(false);
    }

}
