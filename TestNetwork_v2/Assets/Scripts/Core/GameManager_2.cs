using UnityEngine;


public class GameManager_2 : Photon.PunBehaviour
{
    #region Varibles

    public static System.Action<bool> OnActiveMovement;

    const int MIN_PLAYERS_COUNT = 2;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Camera _camera;

    Vector3 startPosition = new Vector3(0, 0.5f, 0);

    #endregion



    #region Unity lifecycle

    void Awake()
    {
        GameObject tempObject = PhotonNetwork.Instantiate(playerPrefab.name, startPosition, Quaternion.identity, 0);
        PlayerController playerController = tempObject.GetComponent<PlayerController>();
        playerController._Camera = _camera; 
    }


    void OnLevelWasLoaded(int level)
    {
        if (PhotonNetwork.playerList.Length >= MIN_PLAYERS_COUNT)
        {
            if (OnActiveMovement != null)
            {
                OnActiveMovement(true);
            }
        }
    }

    #endregion



    #region Photon lifecycle

    public override void OnLeftRoom()
    {
        ReturnToMenu();
    }


    public override void OnDisconnectedFromPhoton()
    {
        ReturnToMenu();
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        if (PhotonNetwork.playerList.Length >= MIN_PLAYERS_COUNT)
        {
            if(OnActiveMovement != null)
            {
                OnActiveMovement(true);
            }
        }
    }


    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        if (PhotonNetwork.playerList.Length < MIN_PLAYERS_COUNT)
        {
            if (OnActiveMovement != null)
            {
                OnActiveMovement(false);
            }
        }
    }

    #endregion



    #region private methods

    void ReturnToMenu()
    {
        PhotonNetwork.LoadLevel(0);
        PhotonNetwork.LeaveRoom();
    }

    #endregion
}
