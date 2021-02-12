using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementV2 : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotSpeed = 5.0f;

    public float leanAmountY = 10f;
    public float leanAmountX = 20f;

    public Transform playerModel;
    public Vector2 limitVector = new Vector2(4, 2);

    private float horizontalInput, verticalInput; 

    private void Update()
    {
        GetKeyBoardInput();
        Movement();

        //playerModel.localRotation = playerModel.localRotation * Quaternion.Euler(new Vector3(0f, 0f, rotSpeed * horizontalInput * Time.deltaTime));

        playerModel.localEulerAngles = new Vector3(verticalInput * leanAmountY, playerModel.localEulerAngles.y, horizontalInput * leanAmountX);

        //RotateForFeel();
    }

    private void GetKeyBoardInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Movement()
    {
        //TODO: remove use of new
        //Make Vectors for right-left and up-down
        Vector3 rightMovement = transform.right * horizontalInput * speed * Time.deltaTime;
        Vector3 upMovement = transform.up * verticalInput * speed * Time.deltaTime;

        //Update player localPosition
        playerModel.localPosition += rightMovement + upMovement;

        //Clamp Position
        //Right and Left
        if (playerModel.localPosition.x > limitVector.x)
        {
            playerModel.localPosition = new Vector3(limitVector.x, playerModel.localPosition.y, playerModel.localPosition.z);
        }
        if (playerModel.localPosition.x < -limitVector.x)
        {
            playerModel.localPosition = new Vector3(-limitVector.x, playerModel.localPosition.y, playerModel.localPosition.z);
        }
        //Up and Down
        if (playerModel.localPosition.y > limitVector.y)
        {
            playerModel.localPosition = new Vector3(playerModel.localPosition.x, limitVector.y, playerModel.localPosition.z);
        }
        if (playerModel.localPosition.y < -limitVector.y)
        {
            playerModel.localPosition = new Vector3(playerModel.localPosition.x, -limitVector.y, playerModel.localPosition.z);
        }
    }

    //private void RotateForFeel()
    //{
    //    if(horizontalInput > 0)
    //    {
    //        transform.localRotation = Quaternion.Slerp(transform.localRotation, transform.localRotation * Quaternion.Euler(turnRot), rotSpeed * Time.deltaTime);
    //    }
    //    if (horizontalInput < 0)
    //    {
    //        transform.localRotation = Quaternion.Slerp(transform.localRotation, transform.localRotation * Quaternion.Euler(turnRot * -1f), rotSpeed * Time.deltaTime);
    //    }

    //    if(verticalInput > 0)
    //    {
    //        transform.localRotation = Quaternion.Slerp(transform.localRotation, transform.localRotation * Quaternion.Euler(upRot), rotSpeed * Time.deltaTime);
    //    }
    //    if (verticalInput < 0)
    //    {
    //        transform.localRotation = Quaternion.Slerp(transform.localRotation, transform.localRotation * Quaternion.Euler(upRot * -1f), rotSpeed * Time.deltaTime);
    //    }
    //}
      
}
