using UnityEngine;


public class PhotonConnect : Photon.PunBehaviour
{
    #region Varibles

    public static System.Action OnNetworkConnected;
    public static System.Action OnNetworkDisconnected;

    string version = "0.1";

    #endregion



    #region Public methods

    public void ConnectToPhoton()
    {
        if (PhotonNetwork.connectionState == ConnectionState.Disconnected)
        {
            PhotonNetwork.ConnectUsingSettings(version);
        }
        Debug.Log("TRY TO CONNECTED!");
    }

    #endregion



    #region Photon lifecycle

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("CONNECTED TO PHOTON!");
    }


    public override void OnJoinedLobby()
    {
        Debug.Log("JOINED!");

        if(OnNetworkConnected != null)
        {
            OnNetworkConnected();
        }
    }


    public override void OnDisconnectedFromPhoton()
    {
        Debug.Log("DISCONNECTED!");

        if(OnNetworkDisconnected != null)
        {
            OnNetworkDisconnected();
        }
    }

    #endregion
}
