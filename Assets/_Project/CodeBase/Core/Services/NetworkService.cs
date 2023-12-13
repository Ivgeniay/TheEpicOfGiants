using Photon.Pun;
using UnityEngine;

namespace CodeBase.Core.Services
{
    internal class NetworkService : MonoBehaviourPunCallbacks
    {
        public bool IsConnected { get; private set; } = false;
        internal void Connect()
        {
            Debug.Log("Connecting...");
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Debug.Log("Connected to Server");
            IsConnected = true;
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Photon.Realtime.RoomOptions options = new();
            Photon.Realtime.TypedLobby lobby = new("Lobby", Photon.Realtime.LobbyType.Default);

            PhotonNetwork.JoinOrCreateRoom("Test", options, lobby);
        }
    }
}
