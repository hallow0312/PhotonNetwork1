using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class View : MonoBehaviour
{
    [SerializeField] TMP_Text nickName;

    private void Start()
    {
        nickName.text = PhotonNetwork.NickName;
    }
    public void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }

}
