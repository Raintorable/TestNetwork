using UnityEngine;


public class PhotonRoom : Photon.PunBehaviour
{

    #region Varibles

    public static System.Action OnRoomReady;

    string roomName;

    #endregion



    #region Public methods

    public void ConnectToRoom(string roomName)
    {
        this.roomName = roomName;
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = 4 }, TypedLobby.Default);
    }

    #endregion



    #region Photon lifecycle

    public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        Debug.Log("FAILED TO CREATE!");
    }


    public override void OnCreatedRoom()
    {
        Debug.Log("CREATED!");
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("JOINED!");

        if (OnRoomReady != null)
        {
            OnRoomReady();
        }
    }

    #endregion
}
