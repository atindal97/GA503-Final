using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketGasMeter : MonoBehaviour
{

    public Slider fuelCollect;

    public gasCollect fuelMeter; 


    // Start is called before the first frame update
    void Start()
    {
        fuelMeter = GameObject.FindGameObjectWithTag("Collect").GetComponent<gasCollect>();
        fuelCollect = GetComponent<Slider>();
        fuelCollect.maxValue = fuelMeter.gasTotal;
        fuelCollect.value = fuelMeter.gasTotal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gasMeter(int gas)
    {
        fuelCollect.value = gas;
    }
}
