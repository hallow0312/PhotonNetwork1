using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rotate))]
public class Head : MonoBehaviourPunCallbacks
{
    
   
    [SerializeField] float x;
    [SerializeField] float speed=200.0f;
  

    public void Update()
    {
        if (photonView.IsMine == false) return;
     
         x= -Input.GetAxis("Mouse Y")*speed *Time.deltaTime;
        x = Mathf.Clamp(x, -90, 90);
        transform.eulerAngles = new Vector3(x, 0, 0);
    }
}
