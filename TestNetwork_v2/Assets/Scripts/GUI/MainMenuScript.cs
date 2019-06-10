using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    #region Varibles

    public static System.Action OnInFigthButtonClick;

    [SerializeField] Button fightButton;

    #endregion



    #region Unity lifecycle

    void Start()
    {
        fightButton.onClick.AddListener(InFigthButtonClick);
    }

    #endregion



    #region Public methods

    public void SetInteractableInFigthButton(bool active)
    {
        fightButton.interactable = active;
    }

    #endregion



    #region Event handlers

    void InFigthButtonClick()
    {
        if(OnInFigthButtonClick != null)
        {
            OnInFigthButtonClick();
        }
    }

    #endregion
}
