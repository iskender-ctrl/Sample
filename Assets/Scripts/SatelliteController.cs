using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatelliteController : MonoBehaviour
{
    public GameObject satelliteMesh;
    private GameObject planet;
    public GameObject explosionPrefabs;
    public int Speed = 1;
    public Transform destroyExplosion;
    void Update()
    {
        if (planet)
        {
            transform.RotateAround(planet.transform.position, Vector3.up, Speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, planet.transform.position, 0.5f * Time.deltaTime);
        }
        if (planet == null)
        {
            Destroy(gameObject);
        }
        Speed = ((int)GameObject.FindGameObjectWithTag("Speed").GetComponent<Slider>().value);
    }
    public void SetMaterial(Material material)
    {
        satelliteMesh.GetComponent<Renderer>().material = material;
    }
    public void SetPlanet(GameObject planet)
    {
        this.planet = planet;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Planet")
        {
            Destroy(Instantiate(destroyExplosion, transform.position, Quaternion.identity).gameObject, 3f);
        }
    }
}

