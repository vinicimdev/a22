using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject spotLight;
    [SerializeField] private AudioSource clickSound;

    Flashlight main;
    private bool isOn = false;

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            SwitchLight();
        }
    }

    private void SwitchLight()
    {
        spotLight.SetActive(isOn);
        clickSound.Play();
        isOn = !isOn;
        Debug.Log("Current light state: " + isOn);
    }

}
