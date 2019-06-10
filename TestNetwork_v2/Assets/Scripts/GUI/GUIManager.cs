using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class GUIManager : MonoBehaviour
{
    #region Varibles

    const string CONNECTION_STRING = "Connected!";
    const string DISCONNECTION_STRING = "Disconnected!";

    [Header("MainWindows")]
    [SerializeField] GameObject friendsList;
    [SerializeField] GameObject friendInfo;
    [SerializeField] MainMenuScript mainMenuScript;
    [SerializeField] Button friendListButton;

    [Header("FriendElements")]
    [SerializeField] GameObject friendElement;
    [SerializeField] GameObject parent;  

    [Header("ConnectingStateElements")]
    [SerializeField] Text connectingStateText;

    [Header("PlayerInfo")]
    [SerializeField] Text playerNicknameText;
    [SerializeField] Text playerBalanceText;
    [SerializeField] Text playerScoreText;

    [Header("FriendInfo")]
    [SerializeField] Text friendNicknameText;
    [SerializeField] Text friendWinText;
    [SerializeField] Text friendLoseText;

    GameObject tempObject;

    #endregion



    #region Unity lifecycle

    void OnEnable()
    {
        FriendsListElementsScript.OnBackButtonClick += FriendsListElementsScript_OnBackButtonClick;
        FillFriendElement.OnFriendElementClick += FillFriendElement_OnFriendElementClick;
        FriendInfoScript.OnBackButtonClick += FriendInfoScript_OnBackButtonClick;
        PhotonConnect.OnNetworkConnected += PhotonConnected_OnNetworkConnected;
        PhotonConnect.OnNetworkDisconnected += PhotonConnected_OnNetworkDisconnected;
    }


    void OnDisable()
    {
        FriendsListElementsScript.OnBackButtonClick -= FriendsListElementsScript_OnBackButtonClick;
        FillFriendElement.OnFriendElementClick -= FillFriendElement_OnFriendElementClick;
        FriendInfoScript.OnBackButtonClick -= FriendInfoScript_OnBackButtonClick;
        PhotonConnect.OnNetworkConnected -= PhotonConnected_OnNetworkConnected;
        PhotonConnect.OnNetworkDisconnected -= PhotonConnected_OnNetworkDisconnected;
    }


    void Start()
    {
        friendListButton.onClick.AddListener(OnFriendsListButtonClick);
    }

    #endregion



    #region Public methods

    public void SetPlayerInfo(Player player)
    {
        playerNicknameText.text = player.Nickname;
        playerBalanceText.text = player.Balance.ToString();
        playerScoreText.text = player.Score.ToString();
    }


    public void SetFriendInList(Friend friend, int index, string friendStatus)
    {
        tempObject = Instantiate(friendElement);
        tempObject.transform.SetParent(parent.transform);
        tempObject.transform.localScale = Vector3.one;
        tempObject.GetComponent<FillFriendElement>().SetElements(friend, index, friendStatus);
    }

    #endregion



    #region Event Handlers

    void OnFriendsListButtonClick()
    {
        friendsList.SetActive(true);
    }


    void FriendsListElementsScript_OnBackButtonClick()
    {
        friendsList.SetActive(false);
        gameObject.SetActive(true);
    }


    void FillFriendElement_OnFriendElementClick(Friend friend)
    {
        friendNicknameText.text = friend.Nickname;
        friendWinText.text = friend.WinCount.ToString();
        friendLoseText.text = friend.LoseCount.ToString();
        friendInfo.SetActive(true);
    }


    void FriendInfoScript_OnBackButtonClick()
    {
        friendInfo.SetActive(false);
    }


    void PhotonConnected_OnNetworkConnected()
    {
        connectingStateText.text = CONNECTION_STRING;
        connectingStateText.color = Color.green;
        mainMenuScript.SetInteractableInFigthButton(true);
    }


    void PhotonConnected_OnNetworkDisconnected()
    {
        connectingStateText.text = DISCONNECTION_STRING;
        connectingStateText.color = Color.red;
        mainMenuScript.SetInteractableInFigthButton(false);
    }

    #endregion
}
