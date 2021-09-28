using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float rotateSpeed = 2f;
    private GameObject plane;
    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("floor");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(plane.transform.position, Vector3.up, Input.GetAxis("Mouse Y") * rotateSpeed);
        }
    }
}
