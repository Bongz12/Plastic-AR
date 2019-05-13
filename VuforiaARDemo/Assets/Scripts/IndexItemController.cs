using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexItemController : MonoBehaviour
{
    private Transform arCamera;

    void Start(){        
        arCamera = Camera.main.GetComponent<Transform>();
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - arCamera.position);
        //transform.LookAt(arCamera);
    }
}
