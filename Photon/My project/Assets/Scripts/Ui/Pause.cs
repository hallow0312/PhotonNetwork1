using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Pause : MonoBehaviourPunCallbacks
{
    
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Photon Lobby");
    }

    public void Resume()
    {
        Mouse.ActiveMouse(false, CursorLockMode.Locked);
        Destroy(gameObject);
    }
    public void Settings()
    {

    }
    public void Quit()
    {
        PhotonNetwork.LeaveRoom();
    }

}
