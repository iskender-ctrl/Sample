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
        planetMesh.GetComponent<Renderer>().material.color = planetColorPool[Random.Range(0, planetColorPool.Length)];
    }
    public bool HasFreeSpace()
    {
        return satellites.Count < satelliteMaxSize;
    }
    public void AddSatellite(GameObject satellite)
    {
        satellite.GetComponent<SatelliteController>().SetPlanet(gameObject);
        satellite.GetComponent<SatelliteController>().SetMaterial(planetMesh.GetComponent<Renderer>().material);
        satellites.Add(satellite);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Satellite")
        {
            for (int i = 0; i < satelliteMaxSize; i++)
            {
                Destroy(col.gameObject);
                satellites.Remove(col.gameObject);
                if (satellites.Count == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
