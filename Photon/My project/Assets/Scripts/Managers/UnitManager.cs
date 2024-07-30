using Photon.Pun;
using System.Collections;
using UnityEngine;
using Photon.Realtime;
using Photon.Chat.UtilityScripts;

public class UnitManager : MonoBehaviourPunCallbacks
{

    [SerializeField] GameObject monsterPrefab;
    [SerializeField] GameObject[] spawner;
    [SerializeField] float time =5.0f;
    [SerializeField] int num;
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
            num = Random.Range(0, spawner.Length);

            PhotonNetwork.InstantiateRoomObject("Unit", spawner[num].transform.position , Quaternion.identity);
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
