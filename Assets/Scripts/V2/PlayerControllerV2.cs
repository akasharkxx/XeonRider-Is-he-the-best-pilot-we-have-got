using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    public float forwardSpeed = 20.0f;

    private void Update()
    {
        transform.position += transform.forward * forwardSpeed * Time.deltaTime;
    }
}
