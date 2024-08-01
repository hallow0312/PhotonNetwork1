using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rotate))]
public class Head : MonoBehaviourPunCallbacks
{
    
   
    [SerializeField] float x;
    [SerializeField] float speed=200.0f;
    
    [SerializeField] float amount =5.0f;
    
    public void Update()
    {
        if (photonView.IsMine == false) return;
     
        x+= -Input.GetAxis("Mouse Y")*speed *Time.deltaTime;
        x = Mathf.Clamp(x, -90, 90);
        transform.localEulerAngles = new Vector3(x, 0, 0);
    }

    public IEnumerator Shake(float timer)
    {
       
        Vector3 StartPosition = transform.position;
        while (timer > 0)
        {
            transform.localPosition = Random.insideUnitSphere * amount + StartPosition;
            timer -= Time.deltaTime;
            yield return null;
        }
        transform.localPosition = StartPosition;
    }
}
