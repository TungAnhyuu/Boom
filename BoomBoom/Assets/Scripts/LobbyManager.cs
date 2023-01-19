using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;


public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject connectScreen, roomListUI, roomPanel, lobbyPanel;
    [SerializeField] private InputField createRoomInput, joinRoomInput;
    public Text roomName;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }



    #region UIMethods
    public override void OnJoinedRoom()
    {
        //PhotonNetwork.LoadLevel(1);
        roomPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;

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
        lobbyPanel.SetActive(false);
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }


    #endregion

}
