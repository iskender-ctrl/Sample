using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject planetMesh;
    private Color[] planetColorPool = { Color.red, Color.yellow, Color.black, Color.green };
    public int satelliteMaxSize = 5;
    public List<GameObject> satellites = new List<GameObject>();
    void Start()
    {
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetColor()
    {
        planetMesh.GetComponent<Renderer>().material.color = planetColorPool[Random.Range(0, planetColorPool.Length - 1)];
    }
    public bool HasFreeSpace()
    {
        return satellites.Count < satelliteMaxSize;
    }
    public void AddSatellite(GameObject satellite)
    {
        satellites.Add(satellite);
    }
}
