using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public float healing= 10f;
    public float range =100f;

    public Camera tpsCam;

    private PlayerControls controls;

    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.Shoot.performed += OnShootPerformed;
        controls.Player.Shoot.canceled += OnShootCanceled;

    }

    private void OnShootPerformed(InputAction.CallbackContext obj)
    {
        //RaycastHit hit;
        //if (Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range))
        //{
            //Debug.Log(hit.transform.name);
        //}
    }

        private void OnShootCanceled(InputAction.CallbackContext obj)
    {
        
    }
}