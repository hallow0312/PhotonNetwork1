using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using System;
public class Information : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI textMeshProUGUI;
    private string roomName;
    //title, �ο� �� ���� ��Ÿ���� ���� 
    public void ConnectRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }
    public void SetData(string name ,int PlayerCount , int maxPlayer)
    {
        roomName = name;
        textMeshProUGUI.fontSize = 50;
        textMeshProUGUI.color = Color.black;
        textMeshProUGUI.alignment = TextAlignmentOptions.Center;
        textMeshProUGUI.text = name + "(" + PlayerCount + " / " + maxPlayer + ")"; 

    }

  
}
