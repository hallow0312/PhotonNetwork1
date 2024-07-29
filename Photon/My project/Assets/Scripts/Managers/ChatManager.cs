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
            //. �׸��� Update( ) �Լ����� InputField�� �Է��� ���� string ������ �����մϴ�.

            //�׷� ���� ä���� �Է��ϰ� Enter Key�� ������ ����
            //RPC �Լ��� ��� Ŭ���̾�Ʈ�� ���۹��� �� �ֵ��� ȣ���մϴ�.
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
        //ChatPrefab �ϳ����� text�� �� ���� 
        GameObject dialog = Instantiate(Resources.Load<GameObject>("String"));
        dialog.GetComponent<Text>().text = message;
        //��ũ�Ѻ� content �� �ڽ����� ��� 
        dialog.transform.SetParent(createTransform);
        //ä�� �Է��� ��� �Է��� �� �ְ� ���� 

        inputField.ActivateInputField();
        //�ؽ�Ʈ �ʱ�ȭ (Enter ġ�� ���� ������ �Է��ߴ� �� ���������ϱ� ����)
        inputField.text = "";
    }
}
