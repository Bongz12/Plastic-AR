using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIndex : MonoBehaviour
{
    public float rotateSpeed = 20f;

    void OnMouseDrag()
    {
        float rotateX = Input.GetAxis("Mouse X")*rotateSpeed*Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotateX*5);
    }
}
