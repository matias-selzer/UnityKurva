using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DragMap : MonoBehaviour
{
    void Update()
    {

        if (Input.GetMouseButton(1)) { 
            Vector3 targetDirection = new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"),0);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            transform.position += targetDirection;
        }
    }
}
