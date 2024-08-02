using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Mouse : MonoBehaviourPunCallbacks
{
    [SerializeField] LayerMask layermask;
    [SerializeField] Ray ray;
    [SerializeField] RaycastHit hit;
    [SerializeField] Vector3 direction;
    [SerializeField] Transform rayposition;
    // Start is called before the first frame update
    void Start()
    {
       ActiveMouse(false, CursorLockMode.Locked);
      
    }

    public void Update()
    {
        if(Input.GetButton("Fire1"))
        {
           
            direction = Camera.main.ScreenPointToRay(Input.mousePosition).direction;
            ray= new Ray(rayposition.position, direction);

            if(Physics.Raycast(ray, out hit,Mathf.Infinity,layermask))
            {
                PhotonView photonObject= hit.collider.gameObject.GetComponent<PhotonView>();

                if (photonObject.IsMine)
                {
                    photonObject.GetComponent<Unit>().Damage(50.0f);
                }
                
            }
           
        }
    }

    public static void ActiveMouse(bool state, CursorLockMode mode )
    {
        Cursor.visible = state;
        Cursor.lockState = mode;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(rayposition.position, direction * 100);
    }
}
