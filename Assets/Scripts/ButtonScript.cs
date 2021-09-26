using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    SatelliteController satelliteSpeed;
    public Slider newSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SliderSpeed()
    {
        satelliteSpeed.Speed = newSpeed.value;
    }
}
