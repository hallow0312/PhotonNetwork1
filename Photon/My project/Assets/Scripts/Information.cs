using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
public class Information : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI textMeshProUGUI;
    //title, 인원 수 등을 나타내기 위함 
    public void ConnectRoom()
    {
        PhotonNetwork.JoinRoom(textMeshProUGUI.text);
    }
    public void RoomData(string name ,int currentStaff , int maxStaff)
    {
        textMeshProUGUI.fontSize = 50;
        textMeshProUGUI.color = Color.black;
        textMeshProUGUI.alignment = TextAlignmentOptions.Center;
        textMeshProUGUI.text = name + "(" + currentStaff + " / " + maxStaff + ")"; 

    }
}
