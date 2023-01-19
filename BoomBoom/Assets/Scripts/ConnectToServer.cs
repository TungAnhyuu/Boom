using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField usernameInput;
    [SerializeField] private GameObject createNameButton;
    public Text buttonText;

    public void OnClickCreateNameButton()
    {
        PhotonNetwork.NickName = usernameInput.text;
        buttonText.text = "Connecting";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnNameField_Changed()
    {
        if (usernameInput.text.Length >= 2)
            createNameButton.SetActive(true);
        else createNameButton.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}
