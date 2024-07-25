using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

[RequireComponent(typeof(Mouse))]
[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Rotate))]
public class Controller : MonoBehaviourPunCallbacks
{
  
    [SerializeField] Camera temporaryCamera;
    [SerializeField] Move move;
    [SerializeField] Rotate rotate;
    [SerializeField] Mouse mouse;
    private void Awake()
    {
        move =GetComponent<Move>();
        rotate = GetComponent<Rotate>();
        mouse= GetComponent<Mouse>();
    }
    void Start()
    {
       if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
            
        }
        else
        {
            temporaryCamera.enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && move != null)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Mouse.ActiveMouse(true, CursorLockMode.None);
            }
            move.OnMove(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            rotate.OnRotate(0,Input.GetAxisRaw("Mouse X"),0);
        }

    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
    }

    
}
