using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWingsRotation : MonoBehaviour
{

    public Vector3 rotateAmount;
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateAmount * rotationSpeed);
    }
}
