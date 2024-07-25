using Photon.Pun;
using System.Collections;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

    [SerializeField] GameObject monsterPrefab; 
    [SerializeField] Vector3 direction;
    private void Start()
    {   
        
        StartCoroutine(CreateMonster());
    }
    
    IEnumerator CreateMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            direction.x = Random.Range(5, 10);
            direction.z = Random.Range(5, 10);
            direction.y = 1.0f;
            monsterPrefab = Resources.Load<GameObject>("Unit");
            PhotonNetwork.InstantiateRoomObject(monsterPrefab.name, direction, Quaternion.identity);
        }
    }
}
