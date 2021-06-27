    using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "1";

    public Text connectionInfoText;
    public Button joinButton;
    
    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        joinButton.interactable = false;
        connectionInfoText.text = "Connecting To Master Server...";
    }
    
    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "Online : Connected to Master Server.";
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = $"Offline : Connection Disabled {cause.ToString()} - Try reconnecting..";

        PhotonNetwork.ConnectUsingSettings();
    }
    
    public void Connect()
    {
        joinButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "Connecting to random room...";

            PhotonNetwork.JoinRandomRoom();
        }

        else
        {
            connectionInfoText.text = $"Offline : Connection Disabled - Try to reconnecting..";

            PhotonNetwork.ConnectUsingSettings();
        }

    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "There is no empty room, Creating new room.";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });

    }
    
    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "Connected to with Room.";
        PhotonNetwork.LoadLevel("Main");
    }
}