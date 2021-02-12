using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController1 : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In m^s-1")] [SerializeField]
    private float controlSpeed = 20f;
    //x Movement values
    [Tooltip("In m")] [SerializeField]
    private float xRange = 4f;
    // y Movement values
    [Tooltip("In m")] [SerializeField]
    private float yRange = 2.5f;
    [SerializeField]
    GameObject[] guns;

    [Header("Screen-position Values")]
    [SerializeField]
    private float positionPitchFactor = -5f;
    [SerializeField]
    private float positionYawFactor = 5f;
    
    [Header("Control-throw Values")]
    [SerializeField]
    private float controlPitchFactor = -20f;
    [SerializeField]
    private float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;
    bool isShooting;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled) 
        {
            ProcessInput();
            //ProcessTranslation();
            ProcessRotation();
            FiringProcessing();
        }
        
    }

    private void ProcessInput()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
    }

    void OnPlayerDeath() // string referenced
    {
        isControlEnabled = false;
    }

    private void ProcessTranslation()
    {
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        
        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;
        
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void FiringProcessing()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
        ActivateGuns();
    }

    private void ActivateGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.SetActive(isShooting);
        }
    }

}
