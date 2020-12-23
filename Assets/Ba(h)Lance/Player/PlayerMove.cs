using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    [Header("Physics")]
    //[SerializeField] private float gravity;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask raycastMask;

    public CharacterController controller;
    private PlayerControls controls;
    private Vector2 stickDirection;
    private Vector3 direction3D;
    private Vector3 totalMovement;
    public Camera mainCam;

    //create the movement functions for the player
    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.Move.performed += OnMovePerformed;
        controls.Player.Move.canceled += OnMoveCanceled;

    }

    //apply actions to the functions

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        stickDirection = obj.ReadValue<Vector2>();
        direction3D = new Vector3(stickDirection.x, 0, stickDirection.y);
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        stickDirection = Vector2.zero;
        direction3D = Vector2.zero;
    }

    void Start()
    {
        //apply compenent to controller
        controller = GetComponent<CharacterController>();
        //call the cam
        mainCam = Camera.main;
    }

    //get the player global moves
    void Update()
    {
        totalMovement = ApplyMove(); //+ ApplyGravity();
        controller.Move(totalMovement*Time.deltaTime);
    }

    private Vector3 ApplyMove()
    {
        if(direction3D == Vector3.zero)
        {
            return Vector3.zero;
        }

        //the cam take the direction of mouse
        var rotation = Quaternion.LookRotation(direction3D);
        // convert vector3 to quaternion --> get the rotation
        rotation *= Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
        //cam rotation on y axis
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //direction to move to
        var moveDirection = rotation * Vector3.forward;
        // end of function, send back to the direction just before * player speed
        return moveDirection.normalized * speed;
    }

    /*private Vector3 ApplyGravity()
    {
        var StartRaycastPos = feet.position;
        var raycast = Physics.Raycast(StartRaycastPos, Vector3.down, 0.1f, raycastMask);
        var directionToFall = Vector3.zero;
        if(raycast)
        {
            Debug.Log("touché");
            totalMovement.y = 0;
        }

        else
        {
            Debug.Log("en l'air");
            directionToFall = new Vector3(0, totalMovement.y + gravity * Time.deltaTime, 0);
        }

        return directionToFall;
    }*/
}
