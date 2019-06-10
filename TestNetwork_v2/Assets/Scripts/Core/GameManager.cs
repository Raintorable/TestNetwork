using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class GameManager : MonoBehaviour
{
    #region Varibles

    const string ROOM_NAME = "testRoom";

    [SerializeField] GUIManager gui;
    [SerializeField] PhotonConnect photonConnect;
    [SerializeField] PhotonRoom photonRoom;

    Player player;

    #endregion



    #region Unity lifecycle

    void OnEnable()
    {
        MainMenuScript.OnInFigthButtonClick += MainMenuScript_OnInFigthButtonClick;
        PhotonRoom.OnRoomReady += PhotonRoom_OnRoomReady;
    }


    void OnDisable()
    {
        MainMenuScript.OnInFigthButtonClick -= MainMenuScript_OnInFigthButtonClick;
        PhotonRoom.OnRoomReady -= PhotonRoom_OnRoomReady;
    }


    void Start()
    {
        player = Player.Instance;
        photonConnect.ConnectToPhoton();

        gui.SetPlayerInfo(player);

        List<Friend> friends = player.GetFriendsList;

        var sortedFriendsList = from f in friends
                                orderby f.Score descending, f.Nickname descending
                                select f;

        string friendStatus = "STATUS";
        int friendIndex = 1;

        foreach (Friend f in sortedFriendsList)
        {
            gui.SetFriendInList(f, friendIndex++, friendStatus);
        }
    }

    #endregion



    #region Event Handlers

    void MainMenuScript_OnInFigthButtonClick()
    {
        photonRoom.ConnectToRoom(ROOM_NAME);
    }


    void PhotonRoom_OnRoomReady()
    {
        PhotonNetwork.LoadLevel(1);
    }

    #endregion
}
