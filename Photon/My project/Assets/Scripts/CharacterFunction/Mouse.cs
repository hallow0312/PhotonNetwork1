using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       ActiveMouse(false, CursorLockMode.Locked);
    }


    public static void ActiveMouse(bool state, CursorLockMode mode )
    {
        Cursor.visible = state;
        Cursor.lockState = mode;
    }
}
