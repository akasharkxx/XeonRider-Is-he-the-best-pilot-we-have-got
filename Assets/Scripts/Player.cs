using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m^s-1")]
    [SerializeField]
    private float Speed = 20f;
    //x Movement values
    [Tooltip("In m")]
    [SerializeField]
    private float xRange = 4f;
    // y Movement values
    [Tooltip("In m")]
    [SerializeField]
    private float yRange = 2.5f;

    [SerializeField]
    private float positionPitchFactor = -5f;
    [SerializeField]
    private float controlPitchFactor = -20f;
    [SerializeField]
    private float positionYawFactor = 5f;
    [SerializeField]
    private float controlRollFactor = -20f;


    float xThrow, yThrow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TranslationProcessing();
        RotationProcessing();
    }

    private void TranslationProcessing()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        
        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;
        
        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;
        
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    private void RotationProcessing()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
