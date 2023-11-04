using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   

    public Transform cameraTransform;

    [SerializeField] public float _camSpeed = 0f; 

    [SerializeField] private float _camSpeedFast = 5f; 

    [SerializeField] private float _camMovementSpeed = 1f;
    [SerializeField] private float _camSmoothness = 10f;

    [SerializeField] private float _camRotationAmount = 1f;
    [SerializeField] private float _camBorderMovement = 5f;

    [SerializeField] private float _maxCamZoom = 30f;
    [SerializeField] private float _minCamZoom = 100f;

    [SerializeField] private float _minZCamMovement = 200f;
    [SerializeField] private float _maxZCamMovement = 700f;
    [SerializeField] private float _minXCamMovement = 200f;
    [SerializeField] private float _maxXCamMovement = 700f;

    [SerializeField] private bool cursorVisible = true;

    public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;

    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    Vector2 pos1;
    Vector2 pos2;

    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    void Update()
    {
        HandleMovementInput();
        HandleMouseInput();
    }

    void HandleMouseInput()
    {
        
        if (Input.mouseScrollDelta.y != 0)
        {

            newZoom += Input.mouseScrollDelta.y * zoomAmount;

            if (newZoom.y <= _maxCamZoom) 
            {
               newZoom = new Vector3(0, _maxCamZoom, -_maxCamZoom);

            } else if (newZoom.y >= _minCamZoom) 
            {
                newZoom = new Vector3(0, _minCamZoom, -_minCamZoom);
            }

        }


        if (Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        } 
        else {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetMouseButton(2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = cursorVisible;

            newRotation *= Quaternion.Euler(Vector3.up * Input.GetAxis("Mouse X"));
        }

    }

    void HandleMovementInput()

    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _camMovementSpeed = _camSpeedFast;
        }
        else
        {
            _camMovementSpeed = _camSpeed;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - _camBorderMovement)
        {
            newPosition += (transform.forward * _camMovementSpeed);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= _camBorderMovement)
        {
            newPosition += (transform.forward * -_camMovementSpeed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - _camBorderMovement)
        {
            newPosition += (transform.right * _camMovementSpeed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= _camBorderMovement)
        {
            newPosition += (transform.right * -_camMovementSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * _camRotationAmount);
        }

        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -_camRotationAmount);
        }

        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;

            if (newZoom.y <= 30)
            {
                newZoom = new Vector3(0, 30, -30);

            }
            
        }

        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
            if (newZoom.y >= 120)
            {
                newZoom = new Vector3(0, 120, -120);
            }
        }

        if (newPosition.x < _minXCamMovement)
        {
            newPosition = new Vector3(_minXCamMovement, transform.position.y, transform.position.z);

        } else if(newPosition.x > _maxXCamMovement)
        {
            newPosition = new Vector3(_maxXCamMovement, transform.position.y, transform.position.z);
        }

        if (newPosition.z < _minZCamMovement)
        {
            newPosition = new Vector3(transform.position.x, transform.position.y, _minZCamMovement);

        }
        else if (newPosition.z > _maxZCamMovement)
        {
            newPosition = new Vector3(transform.position.x, transform.position.y, _maxZCamMovement);
        }


        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * _camSmoothness);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * _camSmoothness);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * _camSmoothness);
    }

   
}
