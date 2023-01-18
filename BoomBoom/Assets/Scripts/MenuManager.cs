using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject userNameScreen, connectScreen, createUserNameButton;
    [SerializeField] private InputField userNameInput, createRoomInput, joinRoomInput;
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        userNameScreen.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    #region UIMethods
    public void OnClickCreateNameButton()
    {
        PhotonNetwork.NickName = userNameInput.text;
        userNameScreen.SetActive(false);
        connectScreen.SetActive(true);
    }

    public void OnNameField_Changed()
    {
        if (userNameInput.text.Length >= 2)
            createUserNameButton.SetActive(true);
        else createUserNameButton.SetActive(false);
    }

    public void OnClickJoinRoom()
    {
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(joinRoomInput.text, ro, TypedLobby.Default); ;
    }

    public void OnClickCreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions { MaxPlayers = 4 });
    }
    #endregion

}
