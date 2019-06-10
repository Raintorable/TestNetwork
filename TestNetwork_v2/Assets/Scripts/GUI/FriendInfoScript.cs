using UnityEngine;
using UnityEngine.UI;


public class FriendInfoScript : MonoBehaviour
{
    #region Varibles

    public static System.Action OnBackButtonClick;

    [SerializeField] Button button;

    #endregion



    #region Unity lifecycle

    void Start()
    {
        button.onClick.AddListener(BackButtonClick);
    }

    #endregion



    #region Event handlers

    void BackButtonClick()
    {
        if(OnBackButtonClick != null)
        {
            OnBackButtonClick();
        }
    }

    #endregion
}
