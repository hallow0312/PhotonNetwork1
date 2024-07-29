using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Chat;
using UnityEngine.UI;
using UnityEditor.VersionControl;

public class ChatManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform createTransform;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") != 0)
        {
            inputField.readOnly = true;
        }
        else
        {
            inputField.readOnly = false;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            //. 그리고 Update( ) 함수에서 InputField에 입력한 값을 string 변수에 저장합니다.

            //그런 다음 채팅을 입력하고 Enter Key를 누르는 순간
            //RPC 함수를 모든 클라이언트가 전송받을 수 있도록 호출합니다.
            inputField.ActivateInputField();
            if (inputField.text.Length==0)
            { 
                return;
            }
            string dialog = PhotonNetwork.NickName + " : " + inputField.text;
            photonView.RPC("Chatting", RpcTarget.All, dialog);
                 
        }
    }
    [PunRPC]
    public void Chatting(string message)
    {
        //ChatPrefab 하나만들어서 text에 값 설정 
        GameObject dialog = Instantiate(Resources.Load<GameObject>("String"));
        dialog.GetComponent<Text>().text = message;
        //스크롤뷰 content 에 자식으로 등록 
        dialog.transform.SetParent(createTransform);
        //채팅 입력후 계속 입력할 수 있게 설정 

        inputField.ActivateInputField();
        //텍스트 초기화 (Enter 치고 나면 기존에 입력했던 거 지워져야하기 때문)
        inputField.text = "";
    }
}
