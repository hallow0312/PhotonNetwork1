using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotate : MonoBehaviour
{
    [SerializeField] private float mouseSpeed = 20.0f;
    [SerializeField] Vector3 direction;
    public void OnRotate(float x ,float y, float z )
    {
        direction.x = x * mouseSpeed;
        direction.y = y * mouseSpeed;
        direction.z=z * mouseSpeed;

        transform.eulerAngles = direction * Time.deltaTime;
       
    }
}
