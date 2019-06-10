using UnityEngine;


public class PlayerNetwork : Photon.MonoBehaviour, IPunObservable
{
    #region Varibles

    [SerializeField] PlayerController playerController;
    [SerializeField] Renderer _renderer;

    float playerSpeed;

    Vector3 correctPlayerPosition;

    Vector3 latestCorrectPos;
    Vector3 onUpdatePos;
    float fraction;

    #endregion



    #region Unity lifecycle

    void OnEnable()
    {
        PlayerController.OnPlayerClick += PlayerController_OnPlayerClick;
    }


    void OnDisable()
    {
        PlayerController.OnPlayerClick -= PlayerController_OnPlayerClick;
    }


    void Awake()
    {
        if(!photonView.isMine)
        {
            playerController.enabled = false;
        }
    }


    void Start()
    {
        playerSpeed = playerController.MoveSpeed;

        latestCorrectPos = transform.position;
        onUpdatePos = transform.position;
    }


    void Update()
    {
        if(!photonView.isMine)
        {
            fraction += Time.deltaTime * playerSpeed;
            transform.localPosition = Vector3.Lerp(onUpdatePos, latestCorrectPos, fraction);
        }
    }

    #endregion



    #region Photon methods

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            Vector2 playerPosition = new Vector2(playerController.PointPosition.x, playerController.PointPosition.z);
            stream.SendNext(playerPosition);
        }
        else
        {
            correctPlayerPosition = (Vector2)stream.ReceiveNext();
            correctPlayerPosition = new Vector3(correctPlayerPosition.x, 0.5f, correctPlayerPosition.y);

            latestCorrectPos = correctPlayerPosition;                
            onUpdatePos = transform.localPosition; 
            fraction = 0;                          
        }
    }

    #endregion



    #region Event handlers

    void PlayerController_OnPlayerClick(GameObject player)
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("SetColorOnOtherClick", PhotonTargets.All, player.GetPhotonView().ownerId.ToString());
    }

    #endregion



    #region PunRPC

    [PunRPC]
    void SetColorOnOtherClick(string toGOViewId, PhotonMessageInfo info)
    {
        int touchedGOId, fromGOId = info.sender.ID;
        int.TryParse(toGOViewId, out touchedGOId);

        if(touchedGOId == photonView.ownerId)
        {
            if (fromGOId == touchedGOId)
            {
                _renderer.material.color = Color.green;
            }
            else
            {
                _renderer.material.color = Color.red;
            }  
        }
    }

    #endregion
}
