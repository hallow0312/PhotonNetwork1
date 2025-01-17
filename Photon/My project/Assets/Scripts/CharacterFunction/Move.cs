using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

   [SerializeField] Vector3 direction;
   
   [SerializeField] float speed = 5.0f;

    public void OnMove(float x,float y, float z )
    {
        direction.x = x;
        direction.y = y;
        direction.z = z;

        direction.Normalize();
        transform.position += transform.TransformDirection((direction) * speed * Time.deltaTime);
        //transform.Translate(direction*speed*Time.deltaTime);
        
    }

}
