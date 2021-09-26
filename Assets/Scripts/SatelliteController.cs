using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatelliteController : MonoBehaviour
{
    public GameObject satelliteMesh;
    private GameObject planet;
    public float Speed = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (planet)
        {
            transform.RotateAround(planet.transform.position, Vector3.up, Speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, planet.transform.position, 0.2f * Time.deltaTime);
        }
        if (planet == null)
        {
            Destroy(gameObject);
        }
    }
    public void SetMaterial(Material material)
    {
        satelliteMesh.GetComponent<Renderer>().material = material;
    }
    public void SetPlanet(GameObject planet)
    {
        this.planet = planet;
    }
}

