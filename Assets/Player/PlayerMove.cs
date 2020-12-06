using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //categories in the inspector
    [Header("physics")]
    [SerializeField] private float gravity;
    [Header("player")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationspeed;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask raycastMask;

    private CharacterController controller;
    private PlayerControls PlayerControls;
    private Vector2 stickDirection;
    private Vector3 direction3D;
    private Vector3 totalMovement;


}
