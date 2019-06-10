using UnityEngine;
using UnityEngine.UI;


public class FillFriendElement : MonoBehaviour
{
    #region Varibles

    public static System.Action<Friend> OnFriendElementClick;

    [SerializeField] Text nicknameText;
    [SerializeField] Text statusText;
    [SerializeField] Text scoreText;
    [SerializeField] Text idText;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Button button;

    Friend friend;

    #endregion



    #region Unity lifecycle

    void Start()
    {
        button.onClick.AddListener(FriendElementClick);    
    }

    #endregion



    #region Public methods

    public void SetElements(Friend friend, int id, string friendStatus)
    {
        this.friend = friend;

        rectTransform.localPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            0);

        nicknameText.text = friend.Nickname;
        statusText.text = friendStatus;
        scoreText.text = friend.Score.ToString();
        idText.text = id.ToString() + ".";
    }

    #endregion



    #region Event handlers

    void FriendElementClick()
    {
        if(OnFriendElementClick != null)
        {
            OnFriendElementClick(friend);
        }
    }

    #endregion
}
