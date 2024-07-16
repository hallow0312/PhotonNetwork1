using PlayFab;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine;
using PlayFab.ClientModels;



public class PlayFabManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField email;
    [SerializeField] InputField password;

    public void Success(LoginResult loginResult)
    {
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.LoadLevel("Photon Lobby");
    }

    public void Success(RegisterPlayFabUserResult result)
    {
        Alarm.Show(result.ToString(), AlarmType.Alarm);
    }

    public void SignUp()
    {
        // RegisterPlayFabUserRequest ������ ������ ����ϱ� ���� Ŭ����
        var request = new RegisterPlayFabUserRequest()
        {
            Email = email.text,
            Password = password.text,
            RequireBothUsernameAndEmail=false

        };

        PlayFabClientAPI.RegisterPlayFabUser
        (   request,
            Success,
            Failure
        );
        
    }
    public void LogIn()
    {
        var request = new LoginWithEmailAddressRequest()
        {
            Email=email.text,
            Password = password.text
        };
        PlayFabClientAPI.LoginWithEmailAddress
        (   request,
            Success,
            Failure
        );
    }

    public void Failure(PlayFabError playFabError)
    {
        Alarm.Show(playFabError.GenerateErrorReport(), AlarmType.Alarm);
    }
}
