using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RigController : MonoBehaviour
{
    [SerializeField]
    private float boostSpeed = 10f;
    [SerializeField]
    private float xSpeed = 10f;
    [SerializeField]
    private float ySpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("boost"))
        {
            transform.position += transform.forward * boostSpeed * Time.deltaTime;
        }
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        //transform.rotation = transform.rotation * Quaternion.Euler(transform.rotation.x, xThrow * speed, transform.rotation.z);
        //transform.rotation = ;
        transform.Rotate(yThrow * ySpeed, xThrow * xSpeed, transform.rotation.z);
        //transform.rotation = Vector3.Angle(transform.forward, );
    }
}
