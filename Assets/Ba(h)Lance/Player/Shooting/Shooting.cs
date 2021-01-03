using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    
    [SerializeField] private Material NewMaterial;
    [SerializeField] private LayerMask playerMask;
    public float healing= 10f;
    public float range =100f;
    public Camera mainCam;
    public CharacterController controller;
    private PlayerControls controls;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;

    

    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.Shoot.performed += OnShootPerformed;
    }

    void OnShootPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Shooting");
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range, playerMask))
        {
            Debug.Log(hit.transform.name);
            //destroy the aimed object
            //Destroy(hit.transform.gameObject);
            // change material
            hit.transform.GetComponent<MeshRenderer>().material=NewMaterial;
            Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    
    }

    void Update()
    {
        //Debug.Log("Working");
        Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward*range);
    }
}