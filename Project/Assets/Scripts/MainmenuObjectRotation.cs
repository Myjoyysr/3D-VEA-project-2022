using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuObjectRotation : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;

    public GameObject cube1;

    void Awake()
    {
        cube1.name = "Self";

    }

    void Update()
    {
        cube1.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

    }
}
