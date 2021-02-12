using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    public Transform playerModel;
    public Vector3 offset = Vector3.zero;

    public float moveLimit = 1.0f;
    public float followSpeed = 1.0f; 

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, playerModel.localPosition + offset, followSpeed * Time.deltaTime);
    }
}
