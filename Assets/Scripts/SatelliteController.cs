using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteController : MonoBehaviour
{
    public GameObject satelliteMesh;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetMaterial(Material material)
    {
        satelliteMesh.GetComponent<Renderer>().material = material;
    }

}
