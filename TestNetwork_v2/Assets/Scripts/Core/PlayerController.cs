using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region Varibles

    public static System.Action<GameObject> OnPlayerClick;

    [SerializeField] float moveSpeed = 5f;

    Camera _camera;

    Vector3 pointPosition;

    bool isCanMoving;

    #endregion



    #region Properties

    public Camera _Camera
    {
        set
        {
            _camera = value;
        }
        get
        {
            return _camera;
        }
    }


    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
    }


    public Vector3 PointPosition
    {
        get
        {
            return pointPosition;
        }
    }

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


    void Update()
    {
        if (isCanMoving && Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && !hit.collider.tag.Equals("Player"))
            {
                pointPosition = hit.point;
            }

            if(hit.collider.tag.Equals("Player"))
            {
                if(OnPlayerClick != null)
                {
                    OnPlayerClick(hit.collider.gameObject);
                }
            }
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(pointPosition.x, transform.position.y, pointPosition.z), moveSpeed * Time.deltaTime);
    }

    #endregion



    #region Event Handlers

    void GameManager_2_OnActiveMovement(bool isActive)
    {
        isCanMoving = isActive;
    }

    #endregion
}
