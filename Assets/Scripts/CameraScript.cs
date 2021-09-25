using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float rotateSpeed=2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update () 
    {
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse Y")*rotateSpeed);
        }
    }
}
