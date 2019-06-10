using UnityEngine;


public class GUIManager_2 : MonoBehaviour
{
    #region Varibles

    [SerializeField] GameObject textObject;

    #endregion



    #region Unity lifecycle

    void OnEnable()
    {
        GameManager_2.OnActiveMovement += GameManager_2_OnActiveMovement;
    }


    void OnDisable()
    {
        GameManager_2.OnActiveMovement -= GameManager_2_OnActiveMovement;
    }

    #endregion



    #region Event handlers

    void GameManager_2_OnActiveMovement(bool isActive)
    {
        textObject.SetActive(!isActive);
    }

    #endregion
}
