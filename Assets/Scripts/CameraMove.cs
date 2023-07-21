using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
    }

/*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float z = transform.position.z - playerTransform.position.z;
            transform.position = transform.position + new Vector3(-z, 0, -z);
            transform.rotation = Quaternion.EulerAngles(0, -90, 0);
            Offset = transform.position - playerTransform.position;
           
        }
    }*/
}
