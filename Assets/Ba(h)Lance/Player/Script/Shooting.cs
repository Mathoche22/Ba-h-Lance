using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public float healing= 10f;
    public float range =100f;

    public Camera mainCam;
    public CharacterController controller;
    private PlayerControls controls;

    private Vector3 shooting;

    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.Shoot.performed += OnShootPerformed;
        controls.Player.Shoot.canceled += OnShootCanceled;

    }

    void OnShootPerformed(InputAction.CallbackContext obj)
    {
        //Debug.Log("Shooting");
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }

    void OnShootCanceled(InputAction.CallbackContext obj)
    {
        

    }

    /*void Update()
    {
        shooting = ApplyShoot();

    }*/

    /*private Vector3 ApplyShoot()
    {
        
    }*/
}