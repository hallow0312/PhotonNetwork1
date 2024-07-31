using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] LayerMask layermask;
    [SerializeField] Ray ray;
    // Start is called before the first frame update
    void Start()
    {
       ActiveMouse(false, CursorLockMode.Locked);
    }

    public void Update()
    {
        if(Input.GetButton("Fire1"))
        {

        }
    }

    public static void ActiveMouse(bool state, CursorLockMode mode )
    {
        Cursor.visible = state;
        Cursor.lockState = mode;
    }
}
