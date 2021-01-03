using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public GameObject UI;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(UI && health<=0)
        {
            healMe();
            ShowUI();
        }
    }

    void healMe()
    {
        Debug.Log("You Dit it");

    }
    
    void ShowUI()
    {
        var go = Instantiate(UI, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>.text = health.ToString();
    }
}
