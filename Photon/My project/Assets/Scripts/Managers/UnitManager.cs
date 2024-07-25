using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] GameManager monsterPrefab;
   
    private void Start()
    {
        
    }
    
    IEnumerator CreateMonster()
    {
        yield return new WaitForSeconds(2.0f);
        
    }
}
