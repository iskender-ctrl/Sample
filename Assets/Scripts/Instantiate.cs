using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject PlanetPrefab;
    public GameObject SatellitePrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InstantiateObjectDetection();
    }
    private void InstantiateObjectDetection()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject planet = InstantiateObject(PlanetPrefab);
            if (planet != null)
            {
                //planet.GetComponent<Material>().color = Color.red;
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Vector3? hitPoint = GetHitPoint();
            if (hitPoint == null)
            {
                return;
            }

            Vector3 hp = (Vector3)hitPoint;

            //Sahnedeki tüm müsait planetleri bul
            GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

            float minDist = Mathf.Infinity;
            GameObject minPlanet = null;

            foreach (GameObject planet in planets)
            {
                if (planet.GetComponent<PlanetController>().HasFreeSpace())
                {
                    float distance = Vector3.Distance(hp, planet.transform.position);

                    if (distance < minDist)
                    {
                        minPlanet = planet;
                        minDist = distance;
                    }
                }
            }
            if (minPlanet != null)
            {
                GameObject satellite = InstantiateObject(SatellitePrefab);
                minPlanet.GetComponent<PlanetController>().AddSatellite(satellite);
            }
        }
    }

    private GameObject InstantiateObject(GameObject instantiatePrefab)
    {
        Vector3? hitPoint = GetHitPoint();
        if (hitPoint != null)
        {
            Vector3 hp = (Vector3)hitPoint;
            return Instantiate(instantiatePrefab, new Vector3(hp.x, 0.01f, hp.z), Quaternion.identity);
        }

        return null;
    }

    private Vector3? GetHitPoint()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            return new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        return null;
    }
}
