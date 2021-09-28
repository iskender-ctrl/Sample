using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetController : MonoBehaviour
{
    public GameObject planetMesh;
    private Color[] planetColorPool = { Color.red, Color.yellow, Color.black, Color.green };
    private int satelliteMaxSize = 5;
    public List<GameObject> satellites = new List<GameObject>();
    public GameObject panel;
    public TMP_InputField sizeMaxSatellite;
    void Start()
    {
        SetColor();
    }
    void Update()
    {
        Vector3 planetPosition = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, 4f, transform.position.z));
        panel.transform.position = planetPosition;
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
        if (satellites.Contains(col.gameObject))
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

    public void OpenPanel()
    {
        panel.SetActive(true);
        panel.GetComponent<Image>().color = planetMesh.GetComponent<Renderer>().material.color;
        panel.GetComponent<Image>().color = new Color(panel.GetComponent<Image>().color.r, panel.GetComponent<Image>().color.g, panel.GetComponent<Image>().color.b, 0.5f);
    }
    public void ClosePanel()
    {
        panel.SetActive(false);
    }
    public void OnClickSizeSatellite()
    {
        satelliteMaxSize = int.Parse(sizeMaxSatellite.text);
    }
    public void OnClickDestroy()
    {
        Destroy(gameObject);
    }
}
