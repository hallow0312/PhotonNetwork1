using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Photon.Pun.Demo.Cockpit;
public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Button createButton;
    [SerializeField] Transform contentTransform;
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_InputField roomPersonInputField;

    private Dictionary<string, RoomInfo> dictionary =new Dictionary<string, RoomInfo>();
    void Update()
    {
        if(roomNameInputField.text.Length>0 && roomPersonInputField.text.Length>0)
        {
            createButton.interactable = true;
        }
        else
        {
            createButton.interactable= false;
        }
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Photon Game");
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = byte.Parse(roomPersonInputField.text);
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(roomNameInputField.text,roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        RemoveRoom();
        UpdateRoom(roomList);
        AddRoom();
    }
    public void RemoveRoom()
    {
        foreach(Transform room in contentTransform)
        {
            Destroy(room.gameObject);
        }
    }
    public void UpdateRoom(List<RoomInfo> roomList)
    {
        for(int i=0; i<roomList.Count; i++)
        {
            if (dictionary.ContainsKey(roomList[i].Name))
            {
                if (roomList[i].RemovedFromList)
                {
                    dictionary.Remove(roomList[i].Name);
                }
                else
                {
                    dictionary[roomList[i].Name] = roomList[i];
                }
            }
            else
            {
                dictionary[roomList[i].Name] = roomList[i];
            }
        }

    }
    public void AddRoom()
    {
        foreach(RoomInfo roomInfo in dictionary.Values)
        {
            //1. Room 오브젝트 생성 
            GameObject temp=Instantiate(Resources.Load<GameObject>("Room"));
            //2. 오브젝트 위치 값 설정 
            temp.transform.SetParent(contentTransform);
            //3. Room 오브젝트 안에 있는 Text 속성 설정 
            temp.GetComponent<Information>().SetData(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);
        }
    }
}
