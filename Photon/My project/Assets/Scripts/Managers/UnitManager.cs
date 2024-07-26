using Photon.Pun;
using System.Collections;
using UnityEngine;
using Photon.Realtime;

public class UnitManager : MonoBehaviourPunCallbacks
{

    [SerializeField] GameObject monsterPrefab; 
    
    [SerializeField] float time =5.0f;
        
    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(CreateMonster());
        }
    }
    
    IEnumerator CreateMonster()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(time);
        while (true)
        {
            PhotonNetwork.InstantiateRoomObject("Unit", Vector3.zero, Quaternion.identity);
            yield return waitForSeconds;
            
        }
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(CreateMonster());
        }
    }




}
